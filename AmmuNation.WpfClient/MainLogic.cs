// <copyright file="MainLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace AmmuNation.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Windows.Threading;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Main logic.
    /// </summary>
    public class MainLogic : IMainLogic
    {
        private static Random rand = new Random();
        private string url = "https://localhost:44364/WeaponsApi/";
        private string randomUrl = "https://localhost:44364/Random/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        private IEditorService editor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainLogic"/> class.
        /// </summary>
        /// <param name="editor">editorservice.</param>
        public MainLogic(IEditorService editor)
        {
            this.editor = editor;
        }

        /// <inheritdoc/>
        public IList<WeaponVM> ApiGetWeapons()
        {
            string json = this.client.GetStringAsync(new Uri(this.url + "all")).Result;
            var list = JsonSerializer.Deserialize<List<WeaponVM>>(json, this.jsonOptions);

            return list;
        }

        /// <inheritdoc/>
        public IList<WeaponVM> ForGetOne(int quantity)
        {
            List<WeaponVM> list = new List<WeaponVM>();

            for (int i = 0; i < quantity; i++)
            {
                string json = this.client.GetStringAsync(new Uri(this.randomUrl + "GetOne")).Result;
                var weapon = JsonSerializer.Deserialize<WeaponVM>(json, this.jsonOptions);

                list.Add(weapon);
            }

            return list;
        }

        /// <inheritdoc/>
        public void ApiDelWeapon(WeaponVM weapon)
        {
            bool success = false;
            if (weapon != null)
            {
                string json = this.client.GetStringAsync(new Uri(this.url + "del/" + weapon.Id.ToString(CultureInfo.CurrentCulture))).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <inheritdoc/>
        public bool ApiEditWeapon(WeaponVM weapon, bool isEditing)
        {
            if (weapon == null)
            {
                return false;
            }

            string myUrl = this.url + (isEditing ? "mod" : "add");

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("id", weapon.Id.ToString(CultureInfo.CurrentCulture));
            }

            postData.Add("stability", weapon.Stability.ToString(CultureInfo.CurrentCulture));
            postData.Add("accuracy", weapon.Accuracy.ToString(CultureInfo.CurrentCulture));
            postData.Add("manufacturer", weapon.Manufacturer.ToString());
            postData.Add("name", weapon.Name.ToString());
            postData.Add("type", weapon.Type.ToString());
            postData.Add("weight", weapon.Weight.ToString(CultureInfo.CurrentCulture));
            postData.Add("caliber", weapon.Caliber.ToString());

            FormUrlEncodedContent formUrlEncodedContent = new FormUrlEncodedContent(postData);
            string json = this.client.PostAsync(new Uri(myUrl), formUrlEncodedContent).Result.Content.ReadAsStringAsync().Result;
            formUrlEncodedContent.Dispose();
            JsonDocument doc = JsonDocument.Parse(json);

            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }

        /// <inheritdoc/>
        public void EditWeapon(WeaponVM weapon, Func<WeaponVM, bool> editorFunc)
        {
            bool success = false;

            WeaponVM clone = new WeaponVM();

            if (weapon != null)
            {
                clone.CopyFrom(weapon);
                success = this.editor.EditWeapon(clone) && this.ApiEditWeapon(clone, true);
            }

            this.SendMessage(success == true);
        }

        /// <inheritdoc/>
        public void AddWeapon()
        {
            WeaponVM weaponVM = new WeaponVM();
            bool success = this.editor.EditWeapon(weaponVM) && this.ApiEditWeapon(weaponVM, false);
            this.SendMessage(success);
        }

        /// <inheritdoc/>
        public void SendMessage(bool success)
        {
            string msg = success ? "Successfull" : "Failed";

            Messenger.Default.Send(msg, "WeaponResult");
        }

        /// <inheritdoc/>
        public string RandomSelection(WeaponVM weapon)
        {
            int number = rand.Next(0, 2);

            if (weapon != null)
            {
                if (number % 2 == 0)
                {
                    string json = this.client.GetStringAsync(new Uri(this.randomUrl + "Select/" + weapon.Id.ToString(CultureInfo.CurrentCulture))).Result;

                    return json.ToString();
                }
                else
                {
                    string json = this.client.GetStringAsync(new Uri(this.randomUrl + "Unselect/" + weapon.Id.ToString(CultureInfo.CurrentCulture))).Result;

                    return json.ToString();
                }
            }

            return "Selection failed";
        }

        /// <inheritdoc/>
        public void DeleteRandomItems(IList<WeaponVM> weapons)
        {
            if (weapons != null)
            {
                foreach (WeaponVM weapon in weapons)
                {
                    this.ApiDelWeapon(weapon);
                }
            }
        }
    }
}
