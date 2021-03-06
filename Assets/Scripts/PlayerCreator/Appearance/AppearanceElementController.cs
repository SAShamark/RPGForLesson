using UnityEngine;

namespace PlayerCreator.Appearance
{
    public class AppearanceElementController
    {
        private readonly AppearanceElementView _view;
        private readonly AppearanceFeatureSprites _appearanceFeatureSprites;
        private readonly SpriteRenderer _spriteRenderer;
        private int _index;
        public int Index => _index;
        public AppearanceFeature AppearanceFeature => _appearanceFeatureSprites.AppearanceFeature;
        public AppearanceElementController(AppearanceElementView view,
            AppearanceFeatureSprites featureSprites, SpriteRenderer spriteRenderer, int index)
        {
            _index = index;
            _view = view;
            _appearanceFeatureSprites = featureSprites;
            _spriteRenderer = spriteRenderer;
            _view.ElementHeader.text = _appearanceFeatureSprites.AppearanceFeature.ToString();
            _view.RightArrow.onClick.AddListener(NextElement);
            _view.LeftArrow.onClick.AddListener(PreviousElement);
            ChangeAppearanceElement();
        }
        private void NextElement()
        {
            _index++;
            if (_index > _appearanceFeatureSprites.Sprites.Count - 1)
            {
                _index = 0;
            }
            ChangeAppearanceElement();
        }
        private void PreviousElement()
        {
            _index--;
            if (_index < 0)
            {
                _index = _appearanceFeatureSprites.Sprites.Count - 1;
            }
            ChangeAppearanceElement();
        }
        private void ChangeAppearanceElement()
        {
            _spriteRenderer.sprite = _appearanceFeatureSprites.Sprites[_index];
            _view.StyleHeader.text = $"style_{_index}";
        }
        public void Dispose()
        {
            _view.RightArrow.onClick.RemoveListener(NextElement);
            _view.LeftArrow.onClick.RemoveListener(PreviousElement);
        }
    }
}