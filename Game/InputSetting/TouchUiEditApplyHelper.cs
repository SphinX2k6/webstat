using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007010 RID: 28688
	[NullableContext(1)]
	[Nullable(0)]
	public class TouchUiEditApplyHelper : IStaticVariableResetter
	{
		// Token: 0x0604573B RID: 284475 RVA: 0x01228E68 File Offset: 0x01227068
		static TouchUiEditApplyHelper()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(TouchUiEditApplyHelper.CreateStaticDefaultValue), new Action(TouchUiEditApplyHelper.ResetStaticDefaultValue));
		}

		// Token: 0x0604573C RID: 284476 RVA: 0x01228E87 File Offset: 0x01227087
		[NullableContext(2)]
		private static bool TryGetDataFacade(ECommonTouchUiEditGroup group, out CommonTouchUiEditDataFacade dataFacade)
		{
			dataFacade = null;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return false;
			}
			dataFacade = ControllerBase<TouchUiEditController>.Instance.GetDataFacade<CommonTouchUiEditDataFacade>();
			if (dataFacade == null)
			{
				return false;
			}
			dataFacade.SetGroup((int)group);
			return true;
		}

		// Token: 0x0604573D RID: 284477 RVA: 0x01228EB8 File Offset: 0x012270B8
		private static void CacheData(UiPanelBase panel, string resId, ITouchUiEditDataFacade dataFacade)
		{
			AActor rootActor = panel.GetRootActor();
			if (rootActor == null || !rootActor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TouchUiEdit;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "遍历触屏键位失败, 传入的Panel可能已经销毁, 请检查调用时机";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Panel", resId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ULGUIComponentsRegistry ulguicomponentsRegistry = rootActor.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) as ULGUIComponentsRegistry;
			if (ulguicomponentsRegistry == null)
			{
				return;
			}
			for (int i = -1; i < ulguicomponentsRegistry.Components.Num(); i++)
			{
				int storageId = dataFacade.GetStorageId(resId, i);
				if (storageId != 0)
				{
					AActor aactor = (i == -1) ? rootActor : ulguicomponentsRegistry.Components.Get(i);
					if (aactor != null)
					{
						UUIItem uuiitem = aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
						if (uuiitem != null && !TouchUiEditApplyHelper.OriginalOffsetCache.ContainsKey(storageId))
						{
							TouchUiEditApplyHelper.OriginalOffsetCache[storageId] = new ValueTuple<float, float>(uuiitem.GetAnchorOffsetX(), uuiitem.GetAnchorOffsetY());
						}
					}
				}
			}
		}

		// Token: 0x0604573E RID: 284478 RVA: 0x01228FA8 File Offset: 0x012271A8
		private static void ApplyData(UiPanelBase panel, string resId, ITouchUiEditDataFacade dataFacade)
		{
			AActor rootActor = panel.GetRootActor();
			if (rootActor == null || !rootActor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TouchUiEdit;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "遍历触屏键位失败, 传入的Panel可能已经销毁, 请检查调用时机";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Panel", resId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ULGUIComponentsRegistry ulguicomponentsRegistry = rootActor.GetComponentByClass(ULGUIComponentsRegistry.StaticClass()) as ULGUIComponentsRegistry;
			if (ulguicomponentsRegistry == null)
			{
				return;
			}
			for (int i = -1; i < ulguicomponentsRegistry.Components.Num(); i++)
			{
				int storageId = dataFacade.GetStorageId(resId, i);
				if (storageId != 0)
				{
					AActor aactor;
					if (i == -1)
					{
						aactor = rootActor;
					}
					else
					{
						aactor = ulguicomponentsRegistry.Components.Get(i);
					}
					if (aactor != null)
					{
						UUIItem uuiitem = aactor.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
						if (uuiitem != null && storageId != 0)
						{
							if (!TouchUiEditApplyHelper.OriginalOffsetCache.ContainsKey(storageId))
							{
								TouchUiEditApplyHelper.OriginalOffsetCache[storageId] = new ValueTuple<float, float>(uuiitem.GetAnchorOffsetX(), uuiitem.GetAnchorOffsetY());
							}
							ITouchUiEditData data = dataFacade.GetData(resId, i);
							if (data.Editable)
							{
								uuiitem.SetUIItemScale(new FVector(data.Scale, data.Scale, data.Scale));
								ValueTuple<float, float> valueTuple2 = TouchUiEditApplyHelper.OriginalOffsetCache[storageId];
								uuiitem.SetAnchorOffsetX(valueTuple2.Item1 + data.OffsetX);
								uuiitem.SetAnchorOffsetY(valueTuple2.Item2 + data.OffsetY);
								uuiitem.SetUIItemAlpha(data.Alpha);
								uuiitem.SetHierarchyIndex(data.HierarchyIndex);
							}
						}
					}
				}
			}
		}

		// Token: 0x0604573F RID: 284479 RVA: 0x01229138 File Offset: 0x01227338
		public static void ApplyCommonTouchUiEditData(ECommonTouchUiEditGroup group, UiPanelBase panel, string resId)
		{
			CommonTouchUiEditDataFacade commonTouchUiEditDataFacade;
			if (!TouchUiEditApplyHelper.TryGetDataFacade(group, out commonTouchUiEditDataFacade) || commonTouchUiEditDataFacade == null)
			{
				return;
			}
			TouchUiEditApplyHelper.ApplyData(panel, resId, commonTouchUiEditDataFacade);
		}

		// Token: 0x06045740 RID: 284480 RVA: 0x0122915C File Offset: 0x0122735C
		public static void CacheTouchUiEditInitData(ECommonTouchUiEditGroup group, UiPanelBase panel, string resId)
		{
			CommonTouchUiEditDataFacade commonTouchUiEditDataFacade;
			if (!TouchUiEditApplyHelper.TryGetDataFacade(group, out commonTouchUiEditDataFacade) || commonTouchUiEditDataFacade == null)
			{
				return;
			}
			TouchUiEditApplyHelper.CacheData(panel, resId, commonTouchUiEditDataFacade);
		}

		// Token: 0x06045741 RID: 284481 RVA: 0x0122917F File Offset: 0x0122737F
		public static void CreateStaticDefaultValue()
		{
			TouchUiEditApplyHelper.OriginalOffsetCache = new Dictionary<int, ValueTuple<float, float>>();
		}

		// Token: 0x06045742 RID: 284482 RVA: 0x0122918B File Offset: 0x0122738B
		public static void ResetStaticDefaultValue()
		{
			TouchUiEditApplyHelper.OriginalOffsetCache = null;
		}

		// Token: 0x04026CFB RID: 158971
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private static Dictionary<int, ValueTuple<float, float>> OriginalOffsetCache;
	}
}
