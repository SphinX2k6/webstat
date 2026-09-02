using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A47 RID: 19015
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiLayer : Singleton<UiLayer>
	{
		// Token: 0x17008481 RID: 33921
		// (get) Token: 0x06031AE1 RID: 203489 RVA: 0x00C60EF4 File Offset: 0x00C5F0F4
		public AActor UiRoot
		{
			get
			{
				return this.UiRootInternal;
			}
		}

		// Token: 0x17008482 RID: 33922
		// (get) Token: 0x06031AE2 RID: 203490 RVA: 0x00C60EFC File Offset: 0x00C5F0FC
		public UUIItem UiRootItem
		{
			get
			{
				return this.UiRootItemInternal;
			}
		}

		// Token: 0x17008483 RID: 33923
		// (get) Token: 0x06031AE3 RID: 203491 RVA: 0x00C60F04 File Offset: 0x00C5F104
		public AActor WorldSpaceUiRoot
		{
			get
			{
				return this.WorldSpaceUiRootInternal;
			}
		}

		// Token: 0x17008484 RID: 33924
		// (get) Token: 0x06031AE4 RID: 203492 RVA: 0x00C60F0C File Offset: 0x00C5F10C
		public UUIItem WorldSpaceUiRootItem
		{
			get
			{
				return this.WorldSpaceUiRootItemInternal;
			}
		}

		// Token: 0x06031AE5 RID: 203493 RVA: 0x00C60F14 File Offset: 0x00C5F114
		private UniTask LoadLayerNode(ELayerType layer, int unitCount)
		{
			UiLayer.<LoadLayerNode>d__21 <LoadLayerNode>d__;
			<LoadLayerNode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLayerNode>d__.<>4__this = this;
			<LoadLayerNode>d__.layer = layer;
			<LoadLayerNode>d__.unitCount = unitCount;
			<LoadLayerNode>d__.<>1__state = -1;
			<LoadLayerNode>d__.<>t__builder.Start<UiLayer.<LoadLayerNode>d__21>(ref <LoadLayerNode>d__);
			return <LoadLayerNode>d__.<>t__builder.Task;
		}

		// Token: 0x06031AE6 RID: 203494 RVA: 0x00C60F68 File Offset: 0x00C5F168
		[NullableContext(1)]
		private UniTask LoadLayerUnit(int index, [Nullable(2)] UUIItem parent, List<UUIItem> unitList, int unitCount)
		{
			UiLayer.<LoadLayerUnit>d__22 <LoadLayerUnit>d__;
			<LoadLayerUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLayerUnit>d__.<>4__this = this;
			<LoadLayerUnit>d__.index = index;
			<LoadLayerUnit>d__.parent = parent;
			<LoadLayerUnit>d__.unitList = unitList;
			<LoadLayerUnit>d__.unitCount = unitCount;
			<LoadLayerUnit>d__.<>1__state = -1;
			<LoadLayerUnit>d__.<>t__builder.Start<UiLayer.<LoadLayerUnit>d__22>(ref <LoadLayerUnit>d__);
			return <LoadLayerUnit>d__.<>t__builder.Task;
		}

		// Token: 0x06031AE7 RID: 203495 RVA: 0x00C60FCC File Offset: 0x00C5F1CC
		public UUIItem GetFloatUnit(ELayerType layer, int index)
		{
			List<UUIItem> list;
			if (!this.FloatUnitMap.TryGetValue(layer, out list))
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.XXJ, "索引大于生成单元节点列表,返回当前最大值节点", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			if (index >= list.Count)
			{
				Singleton<Log>.Instance.Error(ELogModule.UiCore, ELogAuthor.XXJ, "索引大于生成单元节点列表,返回当前最大值节点", default(ReadOnlySpan<ValueTuple<string, object>>));
				List<UUIItem> list2 = list;
				return list2[list2.Count - 1];
			}
			return list[index];
		}

		// Token: 0x06031AE8 RID: 203496 RVA: 0x00C61044 File Offset: 0x00C5F244
		private UniTask LoadPureModeUnit(ELayerType layerType)
		{
			UiLayer.<LoadPureModeUnit>d__24 <LoadPureModeUnit>d__;
			<LoadPureModeUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadPureModeUnit>d__.<>4__this = this;
			<LoadPureModeUnit>d__.layerType = layerType;
			<LoadPureModeUnit>d__.<>1__state = -1;
			<LoadPureModeUnit>d__.<>t__builder.Start<UiLayer.<LoadPureModeUnit>d__24>(ref <LoadPureModeUnit>d__);
			return <LoadPureModeUnit>d__.<>t__builder.Task;
		}

		// Token: 0x06031AE9 RID: 203497 RVA: 0x00C61090 File Offset: 0x00C5F290
		public UUIItem GetPureModeFloatUnit(ELayerType layer)
		{
			UUIItem result;
			if (!this.PureModeFloatUnitMap.TryGetValue(layer, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.CFT;
				string message = "该层级没有纯净模式的节点";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("layer", layer);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x06031AEA RID: 203498 RVA: 0x00C610DC File Offset: 0x00C5F2DC
		public UUIItem GetLayerRootUiItem(ELayerType layerType)
		{
			UUIItem result;
			if (!this.LayerMap.TryGetValue(layerType, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "找不到对应的UiLayer, 此时UiLayer可能还未初始化";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("层级名称", layerType.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x06031AEB RID: 203499 RVA: 0x00C6112F File Offset: 0x00C5F32F
		[NullableContext(1)]
		public UUIItem GetBattleViewUnit(int index)
		{
			return this.BattleViewUnitList[index];
		}

		// Token: 0x06031AEC RID: 203500 RVA: 0x00C61140 File Offset: 0x00C5F340
		public unsafe void SetLayerActive(ELayerType type, bool show)
		{
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(type);
			if (layerRootUiItem != null)
			{
				layerRootUiItem.SetUIActive(show);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiLayer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "有操作设置层级的显隐状态";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("层级类型", type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("显示状态", show);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiLayer;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "找不到对应的uiLayer：";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031AED RID: 203501 RVA: 0x00C611F0 File Offset: 0x00C5F3F0
		[NullableContext(1)]
		public unsafe void SetLayerRenderable(ELayerType type, bool show, string reason)
		{
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(type);
			if (layerRootUiItem != null)
			{
				ULGUIBPLibrary.SetUIRenderable(layerRootUiItem, show);
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiLayer;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "有操作设置层级的可渲染状态";
				<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("层级类型", type);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("可渲染状态", show);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("reason", reason);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.UiLayer;
			ELogAuthor author2 = ELogAuthor.XXJ;
			string message2 = "找不到对应的uiLayer：";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", type);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x06031AEE RID: 203502 RVA: 0x00C612BC File Offset: 0x00C5F4BC
		public UniTask Initialize()
		{
			UiLayer.<Initialize>d__30 <Initialize>d__;
			<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Initialize>d__.<>4__this = this;
			<Initialize>d__.<>1__state = -1;
			<Initialize>d__.<>t__builder.Start<UiLayer.<Initialize>d__30>(ref <Initialize>d__);
			return <Initialize>d__.<>t__builder.Task;
		}

		// Token: 0x06031AEF RID: 203503 RVA: 0x00C61300 File Offset: 0x00C5F500
		private UniTask LoadUiRoot()
		{
			UiLayer.<LoadUiRoot>d__31 <LoadUiRoot>d__;
			<LoadUiRoot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadUiRoot>d__.<>4__this = this;
			<LoadUiRoot>d__.<>1__state = -1;
			<LoadUiRoot>d__.<>t__builder.Start<UiLayer.<LoadUiRoot>d__31>(ref <LoadUiRoot>d__);
			return <LoadUiRoot>d__.<>t__builder.Task;
		}

		// Token: 0x06031AF0 RID: 203504 RVA: 0x00C61344 File Offset: 0x00C5F544
		private UniTask LoadAllLayer()
		{
			UiLayer.<LoadAllLayer>d__32 <LoadAllLayer>d__;
			<LoadAllLayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadAllLayer>d__.<>4__this = this;
			<LoadAllLayer>d__.<>1__state = -1;
			<LoadAllLayer>d__.<>t__builder.Start<UiLayer.<LoadAllLayer>d__32>(ref <LoadAllLayer>d__);
			return <LoadAllLayer>d__.<>t__builder.Task;
		}

		// Token: 0x06031AF1 RID: 203505 RVA: 0x00C61388 File Offset: 0x00C5F588
		private UniTask LoadLayer(ELayerType layerType)
		{
			UiLayer.<LoadLayer>d__33 <LoadLayer>d__;
			<LoadLayer>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLayer>d__.<>4__this = this;
			<LoadLayer>d__.layerType = layerType;
			<LoadLayer>d__.<>1__state = -1;
			<LoadLayer>d__.<>t__builder.Start<UiLayer.<LoadLayer>d__33>(ref <LoadLayer>d__);
			return <LoadLayer>d__.<>t__builder.Task;
		}

		// Token: 0x06031AF2 RID: 203506 RVA: 0x00C613D4 File Offset: 0x00C5F5D4
		private UniTask LoadBattleViewUnit()
		{
			UiLayer.<LoadBattleViewUnit>d__34 <LoadBattleViewUnit>d__;
			<LoadBattleViewUnit>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadBattleViewUnit>d__.<>4__this = this;
			<LoadBattleViewUnit>d__.<>1__state = -1;
			<LoadBattleViewUnit>d__.<>t__builder.Start<UiLayer.<LoadBattleViewUnit>d__34>(ref <LoadBattleViewUnit>d__);
			return <LoadBattleViewUnit>d__.<>t__builder.Task;
		}

		// Token: 0x06031AF3 RID: 203507 RVA: 0x00C61418 File Offset: 0x00C5F618
		private UniTask LoadWorldSpaceUiRoot()
		{
			UiLayer.<LoadWorldSpaceUiRoot>d__35 <LoadWorldSpaceUiRoot>d__;
			<LoadWorldSpaceUiRoot>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadWorldSpaceUiRoot>d__.<>4__this = this;
			<LoadWorldSpaceUiRoot>d__.<>1__state = -1;
			<LoadWorldSpaceUiRoot>d__.<>t__builder.Start<UiLayer.<LoadWorldSpaceUiRoot>d__35>(ref <LoadWorldSpaceUiRoot>d__);
			return <LoadWorldSpaceUiRoot>d__.<>t__builder.Task;
		}

		// Token: 0x06031AF4 RID: 203508 RVA: 0x00C6145C File Offset: 0x00C5F65C
		public void SetUiRootActive(bool show)
		{
			if (this.IsForceHideUi())
			{
				return;
			}
			UUIItem uiRootItemInternal = this.UiRootItemInternal;
			if (uiRootItemInternal == null || !UKismetSystemLibrary.IsValid(uiRootItemInternal))
			{
				return;
			}
			uiRootItemInternal.SetUIActive(show);
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnUiScreenRootVisibleChange, show);
		}

		// Token: 0x06031AF5 RID: 203509 RVA: 0x00C614A0 File Offset: 0x00C5F6A0
		public bool IsUiActive()
		{
			UUIItem uiRootItemInternal = this.UiRootItemInternal;
			return uiRootItemInternal != null && UKismetSystemLibrary.IsValid(uiRootItemInternal) && uiRootItemInternal.IsUIActiveInHierarchy();
		}

		// Token: 0x06031AF6 RID: 203510 RVA: 0x00C614C7 File Offset: 0x00C5F6C7
		public void ForceHideUi()
		{
			if (!ModelBase<SundryModel>.Instance.GmBlueprintGmIsOpen)
			{
				return;
			}
			this.SetUiRootActive(false);
			this.SetWorldUiActive(false);
			this.IsForceHideUiRoot = true;
		}

		// Token: 0x06031AF7 RID: 203511 RVA: 0x00C614EB File Offset: 0x00C5F6EB
		public void ForceShowUi()
		{
			if (!this.IsForceHideUi())
			{
				return;
			}
			this.IsForceHideUiRoot = false;
			this.SetUiRootActive(true);
			this.SetWorldUiActive(true);
		}

		// Token: 0x06031AF8 RID: 203512 RVA: 0x00C6150B File Offset: 0x00C5F70B
		public bool IsForceHideUi()
		{
			return this.IsForceHideUiRoot;
		}

		// Token: 0x06031AF9 RID: 203513 RVA: 0x00C61513 File Offset: 0x00C5F713
		public void SetForceHideUiState(bool show)
		{
			this.IsForceHideUiRoot = !show;
		}

		// Token: 0x06031AFA RID: 203514 RVA: 0x00C61520 File Offset: 0x00C5F720
		public void SetWorldUiActive(bool show)
		{
			if (this.IsForceHideUi())
			{
				return;
			}
			UUIItem worldSpaceUiRootItemInternal = this.WorldSpaceUiRootItemInternal;
			if (worldSpaceUiRootItemInternal != null && UKismetSystemLibrary.IsValid(worldSpaceUiRootItemInternal))
			{
				worldSpaceUiRootItemInternal.SetUIActive(show);
			}
		}

		// Token: 0x06031AFB RID: 203515 RVA: 0x00C61550 File Offset: 0x00C5F750
		[NullableContext(1)]
		public unsafe void SetShowMaskLayer(string tag, bool show)
		{
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(ELayerType.Mask);
			if (layerRootUiItem == null || !layerRootUiItem.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiCore;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "Mask Layer Item无效";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("tag", tag);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("show", show);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return;
			}
			if (show)
			{
				this.MaskTagSet.Add(tag);
			}
			else
			{
				this.MaskTagSet.Remove(tag);
			}
			int count = this.MaskTagSet.Count;
			if (layerRootUiItem != null)
			{
				layerRootUiItem.SetRaycastTarget(count > 0);
			}
		}

		// Token: 0x06031AFC RID: 203516 RVA: 0x00C61605 File Offset: 0x00C5F805
		public void GmClearMask()
		{
			this.MaskTagSet.Clear();
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(ELayerType.Mask);
			if (layerRootUiItem == null)
			{
				return;
			}
			layerRootUiItem.SetRaycastTarget(false);
		}

		// Token: 0x06031AFD RID: 203517 RVA: 0x00C61628 File Offset: 0x00C5F828
		public bool IsInMask()
		{
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(ELayerType.Mask);
			return layerRootUiItem != null && layerRootUiItem.IsRaycastTarget();
		}

		// Token: 0x06031AFE RID: 203518 RVA: 0x00C6164C File Offset: 0x00C5F84C
		[NullableContext(1)]
		public void SetShowNormalMaskLayer(bool show, string lockId = "")
		{
			if (!string.IsNullOrEmpty(this.NormalMaskLock) && (this.NormalMaskLock != lockId || show))
			{
				return;
			}
			UUIItem layerRootUiItem = this.GetLayerRootUiItem(ELayerType.NormalMask);
			if (layerRootUiItem == null)
			{
				return;
			}
			if (layerRootUiItem != null)
			{
				layerRootUiItem.SetRaycastTarget(show);
			}
			if (show && string.IsNullOrEmpty(this.NormalMaskLock) && !string.IsNullOrEmpty(lockId))
			{
				this.NormalMaskLock = lockId;
				return;
			}
			if (!show && lockId == this.NormalMaskLock)
			{
				this.NormalMaskLock = "";
			}
		}

		// Token: 0x06031AFF RID: 203519 RVA: 0x00C616CA File Offset: 0x00C5F8CA
		[NullableContext(1)]
		public Vector2D GetViewportSize()
		{
			if (!ObjectUtils.IsValid(this.UiRootItem))
			{
				return Vector2D.Create();
			}
			return Vector2D.Create((double)this.UiRootItem.GetWidth(), (double)this.UiRootItem.GetHeight());
		}

		// Token: 0x06031B00 RID: 203520 RVA: 0x00C616FC File Offset: 0x00C5F8FC
		private void OnViewPortSizeChanged(FIntPoint newViewportSize)
		{
			Singleton<Log>.Instance.Info(ELogModule.UiCore, ELogAuthor.CFT, "UIRootItem OnViewPortSizeChange", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<EventSystem>.Instance.Emit(EEventName.UIViewPortSizeChanged);
		}

		// Token: 0x0401CE85 RID: 118405
		private bool IsInitializing;

		// Token: 0x0401CE86 RID: 118406
		[Nullable(1)]
		private string NormalMaskLock = "";

		// Token: 0x0401CE87 RID: 118407
		private AActor UiRootInternal;

		// Token: 0x0401CE88 RID: 118408
		private UUIItem UiRootItemInternal;

		// Token: 0x0401CE89 RID: 118409
		private AActor WorldSpaceUiRootInternal;

		// Token: 0x0401CE8A RID: 118410
		private UUIItem WorldSpaceUiRootItemInternal;

		// Token: 0x0401CE8B RID: 118411
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<UUIItem> BattleViewUnitList;

		// Token: 0x0401CE8C RID: 118412
		[Nullable(1)]
		private readonly Dictionary<ELayerType, UUIItem> LayerMap = new Dictionary<ELayerType, UUIItem>();

		// Token: 0x0401CE8D RID: 118413
		private bool IsForceHideUiRoot;

		// Token: 0x0401CE8E RID: 118414
		[Nullable(1)]
		private readonly HashSet<string> MaskTagSet = new HashSet<string>();

		// Token: 0x0401CE8F RID: 118415
		[Nullable(1)]
		private readonly Dictionary<ELayerType, List<UUIItem>> FloatUnitMap = new Dictionary<ELayerType, List<UUIItem>>();

		// Token: 0x0401CE90 RID: 118416
		[Nullable(1)]
		private readonly Dictionary<ELayerType, UUIItem> PureModeFloatUnitMap = new Dictionary<ELayerType, UUIItem>();

		// Token: 0x0401CE91 RID: 118417
		[Nullable(1)]
		private readonly Array LayerTypeArray = Enum.GetValues(typeof(ELayerType));
	}
}
