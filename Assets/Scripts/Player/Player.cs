using Assets.Scripts.Resources;

using System;
using System.Collections.Generic;

namespace Assets.Scripts.player
{
    public class Player
    {
        private Dictionary<ResourceTypes, ResourceItem> _resources = new Dictionary<ResourceTypes, ResourceItem>();

        public Player()
        {

            _resources[ResourceTypes.SkillPoints] = new ResourceItem();
        }

        public void AddResource(Resource res)
        {
            _resources[res.type].AddResouce(res.value);
        }

        public void SpendResource(Resource res)
        {
            _resources[res.type].SpendResouce(res.value);
        }

        public int GetResource(ResourceTypes type)
        {
            return _resources[type].value;
        }

        public void SubscribeResource(ResourceTypes type, Action<int> callback)
        {
            _resources[type].onUpdate += callback;
        }

        public void UnsubscribeResource(ResourceTypes type, Action<int> callback)
        {
            _resources[type].onUpdate -= callback;
        }

    }
}
