using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TreasureHunt;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001FCC RID: 8140
[NullableContext(1)]
[Nullable(0)]
public class TreasureCompassUnit : HudUnitBase
{
	// Token: 0x0600F5B1 RID: 62897 RVA: 0x00434304 File Offset: 0x00432504
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600F5B2 RID: 62898 RVA: 0x0043434C File Offset: 0x0043254C
	protected override UniTask OnCreateAsync()
	{
		TreasureCompassUnit.<OnCreateAsync>d__9 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<TreasureCompassUnit.<OnCreateAsync>d__9>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5B3 RID: 62899 RVA: 0x00434390 File Offset: 0x00432590
	protected override void OnBeforeDestroy()
	{
		foreach (TreasureCompassArrow treasureCompassArrow in this.ArrowItems)
		{
			treasureCompassArrow.Clean();
			treasureCompassArrow.Destroy(null);
		}
		this.ArrowItems.Clear();
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.Clear();
		}
		this.LevelSequencePlayer = null;
	}

	// Token: 0x0600F5B4 RID: 62900 RVA: 0x0043440C File Offset: 0x0043260C
	private UniTask AddArrowItem()
	{
		TreasureCompassUnit.<AddArrowItem>d__11 <AddArrowItem>d__;
		<AddArrowItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AddArrowItem>d__.<>4__this = this;
		<AddArrowItem>d__.<>1__state = -1;
		<AddArrowItem>d__.<>t__builder.Start<TreasureCompassUnit.<AddArrowItem>d__11>(ref <AddArrowItem>d__);
		return <AddArrowItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5B5 RID: 62901 RVA: 0x00434450 File Offset: 0x00432650
	protected override void OnStart()
	{
		base.OnStart();
		this.IsVisible = false;
		this.RingItem = base.GetItem(0);
		foreach (TreasureCompassArrow treasureCompassArrow in this.ArrowItems)
		{
			treasureCompassArrow.GetRootItem().SetUIParent(this.RingItem, false);
		}
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600F5B6 RID: 62902 RVA: 0x004344D8 File Offset: 0x004326D8
	public override void SetActive(bool visibility)
	{
		if (visibility == this.IsVisible)
		{
			return;
		}
		this.IsVisible = visibility;
		if (visibility)
		{
			base.SetActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
			}
		}
		else
		{
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopCurrentSequence(false, false);
			}
			this.PlayCloseAsync().Forget();
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnTreasureCompassUnitVisibleChange, visibility);
	}

	// Token: 0x0600F5B7 RID: 62903 RVA: 0x00434568 File Offset: 0x00432768
	private UniTask PlayCloseAsync()
	{
		TreasureCompassUnit.<PlayCloseAsync>d__14 <PlayCloseAsync>d__;
		<PlayCloseAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayCloseAsync>d__.<>4__this = this;
		<PlayCloseAsync>d__.<>1__state = -1;
		<PlayCloseAsync>d__.<>t__builder.Start<TreasureCompassUnit.<PlayCloseAsync>d__14>(ref <PlayCloseAsync>d__);
		return <PlayCloseAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600F5B8 RID: 62904 RVA: 0x004345AB File Offset: 0x004327AB
	public void InitHide()
	{
		base.SetActive(false);
		this.IsVisible = false;
	}

	// Token: 0x0600F5B9 RID: 62905 RVA: 0x004345BC File Offset: 0x004327BC
	public void RefreshCompass(List<ITreasureData> treasureList, Vector actorLocation)
	{
		int count = treasureList.Count;
		int count2 = this.ArrowItems.Count;
		bool flag = false;
		int num = -1;
		for (int i = 0; i < count; i++)
		{
			ITreasureData treasureData = treasureList[i];
			if (treasureData.IsEnableCompassTracking.GetValueOrDefault())
			{
				num++;
				if (num >= count2 || i >= 5)
				{
					break;
				}
				TreasureCompassArrow treasureCompassArrow = this.ArrowItems[num];
				if (treasureData.IsNearbyTracking.GetValueOrDefault())
				{
					treasureCompassArrow.SetVisible(false);
				}
				else
				{
					flag = true;
					treasureData.Location.Subtraction(actorLocation, this.TempLocation);
					float num2 = (float)Singleton<MathUtils>.Instance.GetAngleByVector2D(this.TempLocation);
					this.TempRotator.Yaw = -num2 + ControllerBase<CameraController>.Instance.MainModel.CameraRotator.Yaw;
					treasureCompassArrow.SetRotation(this.TempRotator.ToUeRotator());
					double? distSquared = treasureData.DistSquared;
					double? highlightRangeSquared = treasureData.HighlightRangeSquared;
					if (distSquared.GetValueOrDefault() < highlightRangeSquared.GetValueOrDefault() & (distSquared != null & highlightRangeSquared != null))
					{
						treasureCompassArrow.SetHighLight(true);
						treasureCompassArrow.GetRootItem().SetAsLastHierarchy();
					}
					else
					{
						double valueOrDefault = ((double)1 - 0.5 * (treasureData.DistSquared - treasureData.HighlightRangeSquared) / (treasureData.RangeSquared - treasureData.HighlightRangeSquared)).GetValueOrDefault(1.0);
						double arrowScale = Singleton<MathUtils>.Instance.Clamp(valueOrDefault, 0.5, 1.0);
						treasureCompassArrow.SetArrowScale(arrowScale);
						treasureCompassArrow.SetHighLight(false);
					}
					treasureCompassArrow.SetVisible(true);
				}
			}
		}
		if (num < 0)
		{
			num = 0;
		}
		for (int j = num; j < count2; j++)
		{
			this.ArrowItems[j].SetVisible(false);
		}
		if (flag && !this.IsVisible)
		{
			this.SetActive(true);
			return;
		}
		if (!flag && this.IsVisible)
		{
			this.SetActive(false);
		}
	}

	// Token: 0x040076C2 RID: 30402
	private const int MAX_ARROW_COUNT = 5;

	// Token: 0x040076C3 RID: 30403
	[StaticVariableRuleIgnore]
	private static readonly Stat RefreshStatsObject = Stat.Create("TreasureCompassUnitRefresh", "", "");

	// Token: 0x040076C4 RID: 30404
	[Nullable(2)]
	private UUIItem RingItem;

	// Token: 0x040076C5 RID: 30405
	private readonly Vector TempLocation = Vector.Create();

	// Token: 0x040076C6 RID: 30406
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x040076C7 RID: 30407
	private readonly List<TreasureCompassArrow> ArrowItems = new List<TreasureCompassArrow>();

	// Token: 0x040076C8 RID: 30408
	private bool IsVisible = true;

	// Token: 0x040076C9 RID: 30409
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;
}
