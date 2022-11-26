using UnityEngine.Events;

namespace Unity.FPS.Gameplay
{
    public class KeyPickup : Pickup
    {
        public UnityAction<bool> OnKeyStateSwitch;

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            byPlayer.HasKey = true;
            OnKeyStateSwitch.Invoke(true);
            Destroy(gameObject);
        }
    }
}
