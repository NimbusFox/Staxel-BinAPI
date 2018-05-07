using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plukit.Base;
using Staxel.Core;
using Staxel.Docks;
using Staxel.Logic;
using Staxel.TileStates.Docks;

namespace NimbusFox.BinAPI {
    class BinTileStateEntityLogic : DockTileStateEntityLogic {
        public BinTileStateEntityLogic(Entity entity) : base(entity) { }

        protected override void AddSite(DockSiteConfiguration config) {
            _dockSites.Add(new BinDockSite(Entity, new DockSiteId(Entity.Id, _dockSites.Count), config));
        }

        public void ProcessBin(EntityUniverseFacade facade) {
            if (_dockSites.Count <= 0) {
                return;
            }

            foreach (var site in _dockSites) {
                if (!site.IsEmpty()) {
                    site.EmptyWithoutExploding(facade);
                }
            }
        }

        public override string AltInteractVerb() {
            return "controlHint.verb.Bin";
        }

        public override bool SuppressInteractVerb() {
            return !HasAnyDockedItems();
        }

        public override Vector3F InteractCursorColour() {
            return HasAnyDockedItems() ? base.InteractCursorColour() : Constants.InteractCursorColour;
        }
    }
}
