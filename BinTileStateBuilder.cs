using System;
using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates;

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
