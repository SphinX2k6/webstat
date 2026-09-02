using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A14 RID: 18964
	[NullableContext(1)]
	[Nullable(0)]
	public class ViewHotKeyHandleFactory
	{
		// Token: 0x060318FB RID: 203003 RVA: 0x00C5A1EC File Offset: 0x00C583EC
		public static ViewHotKeyHandle CreateViewHotKeyHandle(IOpenAndCloseViewHotKey parameters, string handleType)
		{
			Type typeFromHandle;
			if (!ViewHotKeyHandleFactory.ViewHotKeyHandleTypeMap.TryGetValue(handleType, out typeFromHandle))
			{
				typeFromHandle = typeof(ViewHotKeyHandle);
			}
			return (ViewHotKeyHandle)Activator.CreateInstance(typeFromHandle, new object[]
			{
				parameters
			});
		}

		// Token: 0x060318FD RID: 203005 RVA: 0x00C5A230 File Offset: 0x00C58430
		// Note: this type is marked as 'beforefieldinit'.
		static ViewHotKeyHandleFactory()
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			string key = EViewHotKeyHandleType.ViewHotKeyHandle.ToString();
			dictionary[key] = typeof(ViewHotKeyHandle);
			string key2 = EViewHotKeyHandleType.ViewHotKeyHandleRoulette.ToString();
			dictionary[key2] = typeof(ViewHotKeyHandleRoulette);
			string key3 = EViewHotKeyHandleType.ViewHotKeyHandleFunctionMenu.ToString();
			dictionary[key3] = typeof(ViewHotKeyHandleFunctionMenu);
			string key4 = EViewHotKeyHandleType.ViewHotKeyHandleMapView.ToString();
			dictionary[key4] = typeof(ViewHotKeyHandleMapView);
			string key5 = EViewHotKeyHandleType.ViewHotKeyHandleRoleRootView.ToString();
			dictionary[key5] = typeof(ViewHotKeyHandleRoleRootView);
			string key6 = EViewHotKeyHandleType.ViewHotKeyHandleTrapDefenseRoulette.ToString();
			dictionary[key6] = typeof(ViewHotKeyHandleTrapDefenseRoulette);
			string key7 = EViewHotKeyHandleType.ViewHotKeyHandleBackpackView.ToString();
			dictionary[key7] = typeof(ViewHotKeyHandleBackpackView);
			string key8 = EViewHotKeyHandleType.ViewHotKeyHandleQuestView.ToString();
			dictionary[key8] = typeof(ViewHotKeyHandleQuestView);
			ViewHotKeyHandleFactory.ViewHotKeyHandleTypeMap = dictionary;
		}

		// Token: 0x0401CDD4 RID: 118228
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<string, Type> ViewHotKeyHandleTypeMap;
	}
}
