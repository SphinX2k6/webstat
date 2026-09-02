using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D80 RID: 19840
	public class UiNavigationUtil : IStaticVariableResetter
	{
		// Token: 0x06033621 RID: 210465 RVA: 0x00CDA3BC File Offset: 0x00CD85BC
		static UiNavigationUtil()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationUtil.CreateStaticDefaultValue), new Action(UiNavigationUtil.ResetStaticDefaultValue));
		}

		// Token: 0x06033622 RID: 210466 RVA: 0x00CDA3DC File Offset: 0x00CD85DC
		[NullableContext(1)]
		public static string GetFullPathOfActor([Nullable(2)] AActor actor)
		{
			if (actor == null)
			{
				return "null";
			}
			string result = "";
			ULGUIBPLibrary.GetFullPathOfActor(GlobalData.World, actor, ref result);
			return result;
		}

		// Token: 0x06033623 RID: 210467 RVA: 0x00CDA407 File Offset: 0x00CD8607
		public static void CreateStaticDefaultValue()
		{
			UiNavigationUtil.IncId = 0;
		}

		// Token: 0x06033624 RID: 210468 RVA: 0x00CDA40F File Offset: 0x00CD860F
		public static void ResetStaticDefaultValue()
		{
			UiNavigationUtil.IncId = 0;
		}

		// Token: 0x06033625 RID: 210469 RVA: 0x00CDA418 File Offset: 0x00CD8618
		[NullableContext(1)]
		public static IReadOnlyList<string> GetKeyNameListByConfig(HotKeyMap config)
		{
			string actionName = config.ActionName;
			string axisName = config.AxisName;
			if (!string.IsNullOrEmpty(actionName))
			{
				ValueTuple<IReadOnlyList<string>, bool>? platformKeyNameDataByActionName = ModelBase<UiNavigationModel>.Instance.GetPlatformKeyNameDataByActionName(actionName);
				if (platformKeyNameDataByActionName != null)
				{
					if (!platformKeyNameDataByActionName.Value.Item2)
					{
						return new <>z__ReadOnlySingleElementList<string>(platformKeyNameDataByActionName.Value.Item1[0]);
					}
					return platformKeyNameDataByActionName.Value.Item1;
				}
			}
			else if (!string.IsNullOrEmpty(axisName))
			{
				IReadOnlyList<string> platformKeyNameListByAxisName = ModelBase<UiNavigationModel>.Instance.GetPlatformKeyNameListByAxisName(axisName);
				if (platformKeyNameListByAxisName == null)
				{
					return Array.Empty<string>();
				}
				return new <>z__ReadOnlySingleElementList<string>(platformKeyNameListByAxisName[0]);
			}
			return Array.Empty<string>();
		}

		// Token: 0x0401DC87 RID: 121991
		public static int IncId;
	}
}
