using Staxel.EntityActions;
using Staxel.Logic;

namespace NimbusFox.BinAPI {
    public class TriggerBinEntityAction : EntityActionDriver {
        public static string KindCode() {
            return "nimbusfox.entityAction.TriggerBin";
        }

        public override string Kind() {
            return TriggerBinEntityAction.KindCode();
        }

        public override void Start(Entity entity, EntityUniverseFacade facade) {
            if (entity.Logic is BinTileStateEntityLogic logic) {
                logic.ProcessBin(facade);
            }
            entity.Logic.ActionFacade.NoNextAction();
        }
    }
}
