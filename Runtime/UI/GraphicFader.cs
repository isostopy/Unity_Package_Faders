using UnityEngine;
using UnityEngine.UI;

namespace Isostopy.Faders
{
	/// <summary> Permite hacer fade de un elemento de la UI. </summary>

	[AddComponentMenu("Isostopy/Faders/Graphic Fader")]
	public class GraphicFader : Fader
	{
		/// <summary> Elemento de la UI del que vamos a modificar la transparencia. </summary>
		[SerializeField] Graphic target = null;


		// --------------------------------------------------------

		private void Reset()
		{
			target = GetComponent<Graphic>();
		}


		// --------------------------------------------------------

		public override float FadingValue
		{
			get
			{
				return target.color.a;
			}
			protected set
			{
				Color color = target.color;
				color.a = value;
				target.color = color;
			}
		}


		// --------------------------------------------------------

		/// <summary> Elemento de la UI del que hacemos fade. </summary>
		public Graphic Target
		{
			get => target;
			set => target = value;
		}
	}
}
