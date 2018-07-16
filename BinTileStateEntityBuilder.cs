using Plukit.Base;
using Staxel.Logic;
using Staxel.Tiles;
using Staxel.TileStates.Docks;

namespace NimbusFox.BinAPI {
    public class BinTileStateEntityBuilder : DockTileStateEntityBuilder, IEntityPainterBuilder, IEntityLogicBuilder2, IEntityLogicBuilder {
        EntityLogic IEntityLogicBuilder.Instance(Entity entity, bool server) {
            return new BinTileStateEntityLogic(entity);
        }

        EntityPainter IEntityPainterBuilder.Instance() {
            return new BinTileStateEntityPainter(this);
        }

        public new string Kind => BinTileStateEntityBuilder.KindCode;

        public new static string KindCode => "nimbusfox.tileStateEntity.Bin";

        public new static Entity Spawn(EntityUniverseFacade facade, Tile tile, Vector3I location) {
            var entity = new Entity(facade.AllocateNewEntityId(), false, KindCode, true);
            var blob = BlobAllocator.Blob(true);
            blob.SetString(nameof(tile), tile.Configuration.Code);
            blob.SetLong("variant", tile.Variant());
            blob.FetchBlob(nameof(location)).SetVector3I(location);
            blob.FetchBlob("velocity").SetVector3D(Vector3D.Zero);
            entity.Construct(blob, facade);
            facade.AddEntity(entity);
            return entity;
        }
    }
}
