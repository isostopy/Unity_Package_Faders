using UnityEngine;

namespace Isostopy.Faders
{
	/// <summary> Permite hacer fade de un CanvasGroup. </summary>
	[AddComponentMenu("Isostopy/Faders/Canvas Group Fader")]
	public class CanvasGroupFader : Fader
	{
		/// <summary> Canvas group del que vamos a modificar el alpha. </summary>
		[SerializeField] CanvasGroup target = null;


		// --------------------------------------------------------

		private void Reset()
		{
			target = GetComponent<CanvasGroup>();
		}


		// --------------------------------------------------------

		public override float FadingValue
		{
			get
			{
				return target.alpha;
			}
			protected set
			{
				target.alpha = value;
			}
		}


		// --------------------------------------------------------

		/// <summary> CanvasGroup del que hacemos fade. </summary>
		public CanvasGroup Target
		{
			get => target;
			set => target = value;
		}
	}
}
