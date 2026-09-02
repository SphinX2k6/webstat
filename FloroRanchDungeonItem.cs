using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001C59 RID: 7257
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class FloroRanchDungeonItem : GridProxyAbstract<FloroRanchDungeonData>
{
	// Token: 0x0600D3C3 RID: 54211 RVA: 0x00386E44 File Offset: 0x00385044
	protected unsafe override void OnRegisterComponent()
	{
		int num = 11;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIExtendToggleSpriteTransition));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D3C4 RID: 54212 RVA: 0x00387016 File Offset: 0x00385216
	protected override void OnStart()
	{
		this.SubDungeonLayout = new GenericLayout<FloroRanchSubDungeonItem, FloroRanchSubDungeonData>(base.GetHorizontalLayout(2), new Func<FloroRanchSubDungeonItem>(this.CreateSubDungeonItem), null, false, true);
	}

	// Token: 0x0600D3C5 RID: 54213 RVA: 0x00387039 File Offset: 0x00385239
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x0600D3C6 RID: 54214 RVA: 0x00387057 File Offset: 0x00385257
	public override void Refresh(FloroRanchDungeonData data, bool isSelected, int gridIndex)
	{
		this.RefreshItem(data);
	}

	// Token: 0x0600D3C7 RID: 54215 RVA: 0x00387060 File Offset: 0x00385260
	private void RefreshItem(FloroRanchDungeonData data)
	{
		this.Data = data;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.GetDungeonName(), Array.Empty<object>());
		List<FloroRanchSubDungeonData> subDungeonData = data.GetSubDungeonData();
		this.SubDungeonLayout.RefreshByData(subDungeonData, null, false);
		if (!this.Data.IsUnLock)
		{
			this.AddTimer();
		}
		UUIText text = base.GetText(4);
		if (text != null)
		{
			text.SetUIActive(!data.IsUnLock);
		}
		UUIHorizontalLayout horizontalLayout = base.GetHorizontalLayout(2);
		if (horizontalLayout != null)
		{
			horizontalLayout.RootUIComp.Get().SetUIActive(data.IsUnLock);
		}
		UUISprite sprite = base.GetSprite(7);
		if (sprite != null)
		{
			sprite.SetUIActive(!data.IsUnLock && !data.IsDifficulty);
		}
		UUISprite sprite2 = base.GetSprite(8);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(!data.IsUnLock && data.IsDifficulty);
		}
		UUISprite sprite3 = base.GetSprite(5);
		if (sprite3 != null)
		{
			sprite3.SetUIActive(data.IsDifficulty);
		}
		UUISprite numSprite = base.GetSprite(6);
		this.SetSpriteByPath(data.RomeNumIcon, numSprite, false, null, delegate(bool _)
		{
			UUIExtendToggleSpriteTransition uiExtendToggleSpriteTransition = this.GetUiExtendToggleSpriteTransition(10);
			if (data.IsDifficulty)
			{
				FColor color = FColor.FromHex("C8564BFF");
				FExtendToggleSpriteTransitionState transitionState = uiExtendToggleSpriteTransition.TransitionState;
				transitionState.UnCheckedHoverState.Color = color;
				transitionState.UnCheckedPressedState.Color = color;
				transitionState.UnCheckedUnHoverState.Color = color;
			}
			uiExtendToggleSpriteTransition.SetAllStateSprite(numSprite.GetSprite());
		});
		UUISprite numSprite2 = numSprite;
		if (numSprite2 != null)
		{
			numSprite2.SetUIActive(data.IsUnLock);
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.HasRedDot);
	}

	// Token: 0x0600D3C8 RID: 54216 RVA: 0x00387212 File Offset: 0x00385412
	private void UpdateUnlock()
	{
		if (this.Data.IsUnLock)
		{
			this.RefreshItem(this.Data);
		}
	}

	// Token: 0x0600D3C9 RID: 54217 RVA: 0x0038722D File Offset: 0x0038542D
	private void AddTimer()
	{
		this.RemoveTimer();
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
		{
			this.UpdateUnlock();
		}, 1000f, 1f, null, null, true);
	}

	// Token: 0x0600D3CA RID: 54218 RVA: 0x0038725E File Offset: 0x0038545E
	private void RemoveTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x0600D3CB RID: 54219 RVA: 0x00387280 File Offset: 0x00385480
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRedDot));
	}

	// Token: 0x0600D3CC RID: 54220 RVA: 0x0038729E File Offset: 0x0038549E
	protected override void OnBeforeDestroy()
	{
		this.RemoveTimer();
	}

	// Token: 0x0600D3CD RID: 54221 RVA: 0x003872A8 File Offset: 0x003854A8
	private void OnRefreshRedDot(int activityId)
	{
		FloroRanchActivityData activityData = ModelBase<FloroRanchModel>.Instance.GetActivityData(EFloroRanchActivityDataType.Normal, true);
		if (activityData == null || activityData.Id != activityId)
		{
			return;
		}
		UUIItem item = base.GetItem(9);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(this.Data.HasRedDot);
	}

	// Token: 0x0600D3CE RID: 54222 RVA: 0x003872EC File Offset: 0x003854EC
	private void OnClickToggle(EToggleState _)
	{
		if (this.OnToggleCallBack != null)
		{
			this.OnToggleCallBack(this.Data, this.Data.GetLatestSubDungeonData());
		}
	}

	// Token: 0x0600D3CF RID: 54223 RVA: 0x00387314 File Offset: 0x00385514
	public void SetToggleCallBack(Action<FloroRanchDungeonData> callBack)
	{
		this.OnToggleCallBack = delegate(FloroRanchDungeonData dungeonData, FloroRanchSubDungeonData subDungeonData)
		{
			callBack(dungeonData);
		};
	}

	// Token: 0x0600D3D0 RID: 54224 RVA: 0x00387340 File Offset: 0x00385540
	private FloroRanchSubDungeonItem CreateSubDungeonItem()
	{
		return new FloroRanchSubDungeonItem();
	}

	// Token: 0x0600D3D1 RID: 54225 RVA: 0x00387347 File Offset: 0x00385547
	public override object GetKey(FloroRanchDungeonData data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x0600D3D2 RID: 54226 RVA: 0x00387354 File Offset: 0x00385554
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x0600D3D3 RID: 54227 RVA: 0x00387366 File Offset: 0x00385566
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040064C6 RID: 25798
	private FloroRanchDungeonData Data;

	// Token: 0x040064C7 RID: 25799
	private GenericLayout<FloroRanchSubDungeonItem, FloroRanchSubDungeonData> SubDungeonLayout;

	// Token: 0x040064C8 RID: 25800
	[Nullable(2)]
	private TimerHandle TimerHandle;

	// Token: 0x040064C9 RID: 25801
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Action<FloroRanchDungeonData, FloroRanchSubDungeonData> OnToggleCallBack;

	// Token: 0x02007F6A RID: 32618
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x0402B608 RID: 177672
		public const int ToggleRoot = 0;

		// Token: 0x0402B609 RID: 177673
		public const int TextName = 1;

		// Token: 0x0402B60A RID: 177674
		public const int LayoutSubIns = 2;

		// Token: 0x0402B60B RID: 177675
		public const int ItemSubIns = 3;

		// Token: 0x0402B60C RID: 177676
		public const int TextLock = 4;

		// Token: 0x0402B60D RID: 177677
		public const int SpriteDifficultyIcon = 5;

		// Token: 0x0402B60E RID: 177678
		public const int SpriteRomeNum = 6;

		// Token: 0x0402B60F RID: 177679
		public const int SpriteLock = 7;

		// Token: 0x0402B610 RID: 177680
		public const int SpriteDifficultyLock = 8;

		// Token: 0x0402B611 RID: 177681
		public const int ItemRedDot = 9;

		// Token: 0x0402B612 RID: 177682
		public const int SpriteTranRomeNum = 10;
	}
}
