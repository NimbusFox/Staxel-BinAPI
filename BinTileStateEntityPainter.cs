using System.Collections.Generic;
using Plukit.Base;
using Staxel;
using Staxel.Client;
using Staxel.Core;
using Staxel.Draw;
using Staxel.Logic;
using Staxel.Rendering;
using Staxel.TileStates.Docks;

namespace NimbusFox.BinAPI {
    public class BinTileStateEntityPainter : DockTileStateEntityPainter {

        private readonly List<KeyValuePair<NameTag, int>> _siteTags = new List<KeyValuePair<NameTag, int>>();
        private readonly string _defaultNameTagText;

        public BinTileStateEntityPainter(DockTileStateEntityBuilder builder) : base(builder) {
            _defaultNameTagText = ClientContext.LanguageDatabase.GetTranslationString("staxel.merchant.SellBoxDefault");
        }

        public override void BeforeRender(DeviceContext graphics, Vector3D renderOrigin, Entity entity,
            AvatarController avatarController, Timestep renderTimestep) {
            base.BeforeRender(graphics, renderOrigin, entity, avatarController, renderTimestep);

            if (!(entity.Logic is BinTileStateEntityLogic logic)) {
                return;
            }

            var sites = logic.GetSites();

            if (_siteTags.Count != sites.Count) {
                _siteTags.Clear();
                for (var index = 0; index < sites.Count; index++) {
                    _siteTags.Add(new KeyValuePair<NameTag, int>(ClientContext.NameTagRenderer.RegisterNameTag(entity.Id), -1));
                }
            }

            for (var i = 0; i < _siteTags.Count; i++) {
                if (sites[i] is BinDockSite binSite) {
                    _siteTags[i].Key.Setup(binSite.GetWorldPosition(), Constants.NameTagDefaultOffset, "", false, false, false);
                }
            }
        }

        public override string GetItemTag(DockSite site, AvatarController avatar, out bool usePetalTag,
            out string icon) {
            usePetalTag = false;
            icon = "";
            return "";
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            if (!disposing) {
                return;
            }

            foreach (var siteTag in _siteTags) {
                siteTag.Key.Dispose();
            }

            _siteTags.Clear();
        }
    }
}
