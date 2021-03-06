﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BFB.Helpers
{
	public static class CollectionHelper
	{
		public static void AddRange<T>(this IList<T> list, IEnumerable<T> toAdd)
		{
			foreach (T item in toAdd)
			{
				list.Add (item);
			}
		}
	}
}