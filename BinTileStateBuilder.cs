using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plukit.Base;
using Staxel;
using Staxel.Logic;
using Staxel.Rendering;
using Staxel.Tiles;
using Staxel.TileStates;
using Staxel.TileStates.Docks;

namespace NimbusFox.BinAPI {
    public class BinTileStateBuilder : ITileStateBuilder, IDisposable {
        public void Dispose() { }
        public void Load() { }
        public string Kind() {
            return BinTileStateBuilder.KindCode();
        }

        public Entity Instance(Vector3I location, Tile tile, Universe universe) {
            return BinTileStateEntityBuilder.Spawn(universe, tile, location);
        }

        public static string KindCode() {
            return "nimbusfox.tileState.Bin";
        }
    }
}
