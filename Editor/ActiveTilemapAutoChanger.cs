using System.Reflection;
using UnityEditor;

namespace UniActiveTilemapAutoChanger
{
	[InitializeOnLoad]
	internal static class ActiveTilemapAutoChanger
	{
		static ActiveTilemapAutoChanger()
		{
			EditorApplication.hierarchyChanged += OnChanged;
		}

		private static void OnChanged()
		{
			var assembly = typeof( AssetDatabase ).Assembly;
			var type     = assembly.GetType( "UnityEditor.GridPaintingState" );
			var property = type.GetProperty( "scenePaintTarget", BindingFlags.Public | BindingFlags.Static );

			property.SetValue( type, Selection.activeGameObject );
		}
	}
}