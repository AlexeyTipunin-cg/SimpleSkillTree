
using System;

namespace Assets.Scripts.Resources
{
    public class ResourceItem
    {
        public event Action<int> onUpdate;
        private Resource _value;

        public ResourceItem()
        {
            _value = new Resource();
        }

        public int value => _value.value;

        public void AddResouce(int value)
        {
            _value.value += value;
            onUpdate?.Invoke(_value.value);
        }

        public void SpendResouce(int value)
        {
            _value.value -= value;
            onUpdate?.Invoke(_value.value);
        }



    }
}
