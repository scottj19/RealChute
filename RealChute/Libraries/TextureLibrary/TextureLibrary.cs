﻿using System.Collections.Generic;
using System.Linq;

/* RealChute was made by Christophe Savard (stupid_chris). You are free to copy, fork, and modify RealChute as you see
 * fit. However, redistribution is only permitted for unmodified versions of RealChute, and under attribution clause.
 * If you want to distribute a modified version of RealChute, be it code, textures, configs, or any other asset and
 * piece of work, you must get my explicit permission on the matter through a private channel, and must also distribute
 * it through the attribution clause, and must make it clear to anyone using your modification of my work that they
 * must report any problem related to this usage to you, and not to me. This clause expires if I happen to be
 * inactive (no connection) for a period of 90 days on the official KSP forums. In that case, the license reverts
 * back to CC-BY-NC-SA 4.0 INTL.*/

namespace RealChute.Libraries
{
    public class TextureLibrary
    {
        #region Instance
        private static TextureLibrary _instance = null;
        /// <summary>
        /// Creates a new instance
        /// </summary>
        public static TextureLibrary instance
        {
            get
            {
                if (_instance == null) { _instance = new TextureLibrary(); }
                return _instance;
            }
        }
        #endregion

        #region Propreties
        private List<TextureConfig> _configs = new List<TextureConfig>();
        /// <summary>
        /// List of all the current texture configs
        /// </summary>
        public List<TextureConfig> configs
        {
            get { return this._configs; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new instance of the library
        /// </summary>
        public TextureLibrary()
        {
            _configs.AddRange(GameDatabase.Instance.GetConfigNodes("TEXTURE_LIBRARY").Select(n => new TextureConfig(n)));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Determines if the config of the given name exists in the library.
        /// </summary>
        /// <param name="name">Name of the searched config</param>
        public bool ConfigExists(string name)
        {
            return configs.Any(config => config.name == name);
        }

        /// <summary>
        /// Returns the config of the given name.
        /// </summary>
        /// <param name="name">Name of the config searched for</param>
        public TextureConfig GetConfig(string name)
        {
            return configs.Single(config => config.name == name);
        }

        /// <summary>
        /// Sees if the config exists and stores it in the ref value if so.
        /// </summary>
        /// <param name="name">Name of the config searched for</param>
        /// <param name="config">Variable to store the result in</param>
        public bool TryGetConfig(string name, ref TextureConfig config)
        {
            if (ConfigExists(name))
            {
                config = GetConfig(name);
                return true;
            }
            if (name != "none" && name != string.Empty) { UnityEngine.Debug.LogWarning("[RealChute]: Could not find the " + name + " texture config in the GameData folder"); }
            return false;
        }
        #endregion
    }
}
