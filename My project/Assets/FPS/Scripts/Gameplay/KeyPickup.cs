namespace Unity.FPS.Gameplay
{
    public class KeyPickup : Pickup
    {
        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            byPlayer.HasKey = true;
        }
    }
}
