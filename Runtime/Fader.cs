using System.Collections;
using UnityEngine;

namespace Isostopy.Faders
{
	/// <summary> Clase base para que hereden otros Fader. </summary>
	public abstract class Fader : MonoBehaviour
	{
		/// <summary> Tiempo por defecto que dura el fade. </summary>
		[Space][SerializeField][Min(0)] protected float fadingTime = 1.0f;

		/// <summary> Si esta haciendo fade o no. </summary>
		bool fading = false;
		/// <summary> Corrutina activa. </summary>
		Coroutine fadingRoutine = null;


		// ----------------------------------------------------
		#region Fade

		/// <summary> Inicia un fade. </summary>
		public void Fade(bool value)
		{
			Fade(value, fadingTime);
		}

		/// <summary> Inicia un fade que dura el tiempo indicado. </summary>
		public void Fade(bool value, float fadingTime)
		{
			// Si el GameObject esta desactivado, poner directamente en el estado final.
			if (gameObject.activeInHierarchy == false)      /// Las corrutinas no pueden activarse con el GameObject inactivo.
			{
				float targetFadingValue = value ? 1 : 0;
				FadingValue = targetFadingValue;
				return;
			}

			// Inicia la corrutina.
			if (fadingRoutine != null) StopCoroutine(fadingRoutine);
			fadingRoutine = StartCoroutine(FadingRoutine(value, fadingTime));
		}

		// --------------------------

		/// <summary> Corrutina que lleva el FadingValue a 1 o a 0. </summary>
		IEnumerator FadingRoutine(bool value, float fadingTime)
		{
			float start = value == true ? 0 : 1;    /* Empieza transparente y termina opaco		*/
			float end = value == true ? 1 : 0;      /* o empieza opaco y termina transparente.	*/

			/// El contador de tiempo empieza en el punto que sea que empieza el FadingValue.
			/// Para que si el alpha ya esta a medio camino, el fade dure la mitad del tiempo.
			float timeCounter = Mathf.Lerp(start * fadingTime, end * fadingTime, FadingValue);

			fading = true;

			// Ir cambiando el valor del fade hasta llegar al objetivo.
			while (timeCounter < fadingTime)
			{
				float progress = timeCounter / fadingTime;
				FadingValue = Mathf.Lerp(start, end, progress);

				timeCounter += Time.deltaTime;
				yield return null;
			}

			fading = false;
			FadingValue = end;
		}

		#endregion


		// ----------------------------------------------------
		#region Inheritance

		/// <summary> Valor entre 0 y 1 del fade. </summary>
		public abstract float FadingValue { get; protected set; }

		#endregion

		#region Public 

		/// <summary> Si esta haciendo fade o no. </summary>
		public bool Fading => fading;

		/// <summary> Tiempo que dura el fade. </summary>
		public float FadingTime
		{
			get => fadingTime;
			set => fadingTime = value;
		}

		#endregion
	}
}
