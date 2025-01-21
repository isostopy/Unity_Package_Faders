using UnityEngine;

namespace Isostopy.Faders
{
	/// <summary> Permite hacer fade de la propiedad indicada de los materiales de un modelo. </summary>

	[AddComponentMenu("Isostopy/Faders/Material Value Fader")]
	public class MaterialValueFader : Fader
	{
		/// <summary> Renderer cuyos materiales vamos a modificar. </summary>
		[Space][SerializeField] Renderer target = null;
		/// <summary> Propiedad de los materiales que vamos a modificar. </summary>
		[SerializeField] string materialProperty = "_Emission";


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
					return target.material.GetFloat(materialProperty);
				return 0;
			}
			protected set
			{
				foreach (Material material in target.materials)
					material.SetFloat(materialProperty, value);
			}
		}


		// ----------------------------------------------------

		/// <summary> Renderer del modelo del que hacemos fade. </summary>
		public Renderer Target
		{
			get => target;
			set => target = value;
		}

		/// <summary> Propiedad de los materiales de la que vamos a hacer fade. </summary>
		public string MaterialProperty
		{
			get => materialProperty;
			set => materialProperty = value;
		}
	}
}
