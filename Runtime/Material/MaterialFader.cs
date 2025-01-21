using UnityEngine;

namespace Isostopy.Faders
{
	/// <summary> Permite hacer fade de un modelo 3D, cambiando el alpha de sus materiales. </summary>

	[AddComponentMenu("Isostopy/Faders/Material Fader")]
	public class MaterialFader : Fader
	{
		/// <summary> Renderer cuyos materiales vamos a modificar. </summary>
		[SerializeField] Renderer target = null;


		// ----------------------------------------------------

		private void Reset()
		{
			target = GetComponent<Renderer>();
		}


		// ----------------------------------------------------

		public override float FadingValue
		{
			get
			{
				if (target.materials.Length > 0)
					return target.material.color.a;
				return 0;
			}
			protected set
			{
				foreach (Material material in target.materials)
				{
					Color color = material.color;
					color.a = value;
					material.color = color;
				}
			}
		}


		// ----------------------------------------------------

		/// <summary> Renderer del modelo del que hacemos fade. </summary>
		public Renderer Target
		{
			get => target;
			set => target = value;
		}
	}
}
