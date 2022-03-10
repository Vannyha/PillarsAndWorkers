using Helpers;
using UnityEngine;

namespace Components
{
    public class Pillar : MonoBehaviour
    {
        private GameColor currentColor = GameColor.None;
        [SerializeField] private Renderer renderer;

        public GameColor CurrentColor => currentColor;
        public bool Inactive => currentColor == GameColor.None;

        //Тут может быть ещё логика, так что не стал добавлять сеттер в CurrentColor
        public void FixPillar()
        {
            SetPillarColor(GameColor.None);
        }

        public void SetPillarColor(GameColor color)
        {
            ShaderHelper.SetMaterialsColorProperty(renderer, ShaderHelper.ColorPropertyID, ColorHelper.GetRGBFromGameColor(color));
            currentColor = color;
        }
    }
}