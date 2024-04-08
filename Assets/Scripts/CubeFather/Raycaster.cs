using System;
using UnityEngine;

namespace CubeFather
{
	public class Raycaster : MonoBehaviour
	{
		private Mediator _mediator;
		private void Awake() =>
			_mediator = new Mediator();

		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.TryGetComponent(out CubeFather cubeFather))
						_mediator.Interract(cubeFather);
				}
			}
		}
	}
}