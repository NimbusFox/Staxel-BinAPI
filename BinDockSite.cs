﻿using Plukit.Base;
using Staxel.Docks;
using Staxel.Effects;
using Staxel.Logic;
using Staxel.Player;
using Staxel.TileStates.Docks;

namespace NimbusFox.BinAPI {
    public class BinDockSite : DockSite {
        public BinDockSite(Entity entity, DockSiteId id, DockSiteConfiguration dockSiteConfig) : base(entity, id, dockSiteConfig) { }

        public override bool TryDock(Entity user, EntityUniverseFacade facade, ItemStack stack, uint rotation) {
            if (CanDock(stack) <= 0) {
                return false;
            }

            var entry = FindEntry(stack.Item);

            if (!entry.PlaceSoundGroup.IsNullOrEmpty()) {
                BaseEffects.PlaySound(_entity, entry.PlaceSoundGroup);
            }

            if (!entry.EffectTrigger.IsNullOrEmpty()) {
                EffectQueue.Trigger(new EffectTrigger(entry.EffectTrigger));
            }

            AddToDock(user, stack, entry, rotation);
            return true;
        }

        public override bool TryUndock(PlayerEntityLogic player, EntityUniverseFacade facade, int quantity) {
            if (IsEmpty() || DockedItem.DockingEntity != player.PlayerEntity.Id) {
                return false;
            }

            var flag = base.TryUndock(player, facade, quantity);

            return flag;
        }
    }
}
