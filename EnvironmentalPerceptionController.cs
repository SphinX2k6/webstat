using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.LevelGamePlay.UnopenedArea;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x020034AA RID: 13482
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[TickController(0)]
public class EnvironmentalPerceptionController : ControllerBase<EnvironmentalPerceptionController>
{
	// Token: 0x0601C6F6 RID: 116470 RVA: 0x008862E5 File Offset: 0x008844E5
	protected override bool OnInit()
	{
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		this.CheckIsPlayerInMapPolygonStat = Stat.Create("CheckIsPlayerInMapPolygon", "", "");
		return true;
	}

	// Token: 0x0601C6F7 RID: 116471 RVA: 0x00886320 File Offset: 0x00884520
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRole));
		if (this.TagComp != null)
		{
			this.TagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], new BaseTagComponent.TTagSwitchedCallback(this.OnPlayerEnterFight));
		}
		this.TagComp = null;
		this.MoveComp = null;
		return true;
	}

	// Token: 0x0601C6F8 RID: 116472 RVA: 0x00886386 File Offset: 0x00884586
	protected override bool OnLeaveLevel()
	{
		return true;
	}

	// Token: 0x0601C6F9 RID: 116473 RVA: 0x0088638C File Offset: 0x0088458C
	private void OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity)
	{
		if (this.TagComp != null)
		{
			this.TagComp.RemoveTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], new BaseTagComponent.TTagSwitchedCallback(this.OnPlayerEnterFight));
		}
		this.MoveComp = Singleton<EntitySystem>.Instance.GetComponent<CharacterMoveComponent>(newEntity.Id);
		this.TagComp = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(newEntity.Id);
		BaseTagComponent tagComp = this.TagComp;
		if (tagComp == null)
		{
			return;
		}
		tagComp.AddTagAddOrRemoveListener(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.进入战斗"], new BaseTagComponent.TTagSwitchedCallback(this.OnPlayerEnterFight), null);
	}

	// Token: 0x0601C6FA RID: 116474 RVA: 0x0088641F File Offset: 0x0088461F
	private void OnPlayerEnterFight(int tagId, bool tagExist)
	{
		this.IsPlayerInFight = tagExist;
	}

	// Token: 0x0601C6FB RID: 116475 RVA: 0x00886428 File Offset: 0x00884628
	protected override void OnTick(float deltaTime)
	{
		this.TickRemain -= (int)(deltaTime * ModelBase<CharacterModel>.Instance.InverseSelfCenteredTimeDilation);
		if (Global.BaseCharacter == null || this.MoveComp == null || this.MoveComp.CharacterMovement == null)
		{
			return;
		}
		if (this.MoveComp.IsMoving)
		{
			if (this.IsPlayerInFight)
			{
				this.TickRemain -= (int)(deltaTime * 16f);
			}
			else
			{
				this.TickRemain -= (int)(deltaTime * 80f);
			}
		}
		if (this.MoveComp.GetLastUpdateVelocity().Size() > 850f)
		{
			this.TickRemain = -1;
		}
		if (this.TickRemain < 0)
		{
			this.TickRemain = 8000;
			ControllerBase<SimpleNpcController>.Instance.UpdateDistanceLogic();
			this.CheckIsPlayerInMapPolygon();
		}
	}

	// Token: 0x0601C6FC RID: 116476 RVA: 0x008864F4 File Offset: 0x008846F4
	private void CheckIsPlayerInMapPolygon()
	{
		if (ModelBase<PlotModel>.Instance.IsInPlot)
		{
			return;
		}
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		if (characterActorComponent == null)
		{
			return;
		}
		if (!ModelBase<MapModel>.Instance.IsInMapPolygon(characterActorComponent.ActorLocationProxy))
		{
			ControllerBase<UnopenedAreaController>.Instance.OnEnterUnopenedArea();
			return;
		}
		ControllerBase<UnopenedAreaController>.Instance.OnExitUnopenedArea();
	}

	// Token: 0x0601C6FD RID: 116477 RVA: 0x0088654C File Offset: 0x0088474C
	public void InitializeEnvironment()
	{
		ushort gridWidth = 3000;
		ushort gridHeight = 3000;
		TMap<FName, uint> tmap = new TMap<FName, uint>();
		for (int i = 0; i < CreatureModel.globalEntityTypePerceptionType.Length; i++)
		{
			tmap.Add(EntityHelperConstants.GlobalEntityTypeQueryName[i], (uint)CreatureModel.globalEntityTypePerceptionType[i]);
		}
		tmap.Add(new FName("CustomStabilizeLow"), 2U);
		tmap.Add(new FName("AlwaysTickHotFix"), 7U);
		UKuroPerceptionInterface.InitializeEnvironment(gridWidth, gridHeight, tmap, true, true);
	}

	// Token: 0x0601C6FE RID: 116478 RVA: 0x008865C2 File Offset: 0x008847C2
	private static PlayerPerceptionEvent PerceptionEventCreator()
	{
		return new PlayerPerceptionEvent();
	}

	// Token: 0x0601C6FF RID: 116479 RVA: 0x008865CC File Offset: 0x008847CC
	public PlayerPerceptionEvent CreatePlayerPerceptionEvent()
	{
		PlayerPerceptionEvent playerPerceptionEvent = this.PerceptionEventPool.Get();
		if (playerPerceptionEvent == null)
		{
			return this.PerceptionEventPool.Create();
		}
		return playerPerceptionEvent;
	}

	// Token: 0x0601C700 RID: 116480 RVA: 0x008865F5 File Offset: 0x008847F5
	[NullableContext(2)]
	public void DestroyPlayerPerceptionEvent(PlayerPerceptionEvent @event)
	{
		if (@event == null)
		{
			return;
		}
		@event.Clear();
		this.PerceptionEventPool.Put(@event);
	}

	// Token: 0x0601C701 RID: 116481 RVA: 0x0088660E File Offset: 0x0088480E
	private static PerceptionRange PerceptionRangeCreator()
	{
		return new PerceptionRange();
	}

	// Token: 0x0601C702 RID: 116482 RVA: 0x00886618 File Offset: 0x00884818
	public PerceptionRange CreatePerceptionRange()
	{
		PerceptionRange perceptionRange = this.PerceptionRangePool.Get();
		if (perceptionRange == null)
		{
			return this.PerceptionRangePool.Create();
		}
		return perceptionRange;
	}

	// Token: 0x0601C703 RID: 116483 RVA: 0x00886641 File Offset: 0x00884841
	[NullableContext(2)]
	public void DestroyPerceptionRange(PerceptionRange range)
	{
		if (range == null)
		{
			return;
		}
		range.Clear();
		this.PerceptionRangePool.Put(range);
	}

	// Token: 0x0601C704 RID: 116484 RVA: 0x0088665C File Offset: 0x0088485C
	public EnvironmentalPerceptionController()
	{
		int capacity = 32;
		Func<PlayerPerceptionEvent> creator;
		if ((creator = EnvironmentalPerceptionController.<>O.<0>__PerceptionEventCreator) == null)
		{
			creator = (EnvironmentalPerceptionController.<>O.<0>__PerceptionEventCreator = new Func<PlayerPerceptionEvent>(EnvironmentalPerceptionController.PerceptionEventCreator));
		}
		this.PerceptionEventPool = new Pool<PlayerPerceptionEvent>(capacity, creator, null);
		int capacity2 = 32;
		Func<PerceptionRange> creator2;
		if ((creator2 = EnvironmentalPerceptionController.<>O.<1>__PerceptionRangeCreator) == null)
		{
			creator2 = (EnvironmentalPerceptionController.<>O.<1>__PerceptionRangeCreator = new Func<PerceptionRange>(EnvironmentalPerceptionController.PerceptionRangeCreator));
		}
		this.PerceptionRangePool = new Pool<PerceptionRange>(capacity2, creator2, null);
		base..ctor();
	}

	// Token: 0x0400E4D2 RID: 58578
	private const int TICK_INTERNVAL = 8000;

	// Token: 0x0400E4D3 RID: 58579
	private const int TICK_DAMPING_RATIO = 80;

	// Token: 0x0400E4D4 RID: 58580
	private const int TICK_DAMPING_RATIO_INFIGHT = 16;

	// Token: 0x0400E4D5 RID: 58581
	private const int FORCE_UPDATE_SPEED = 850;

	// Token: 0x0400E4D6 RID: 58582
	private const int PERCEPTION_EVENT_POOL_CAPACITY = 32;

	// Token: 0x0400E4D7 RID: 58583
	private int TickRemain = 8000;

	// Token: 0x0400E4D8 RID: 58584
	[Nullable(2)]
	private CharacterMoveComponent MoveComp;

	// Token: 0x0400E4D9 RID: 58585
	[Nullable(2)]
	private BaseTagComponent TagComp;

	// Token: 0x0400E4DA RID: 58586
	[Nullable(2)]
	private Stat CheckIsPlayerInMapPolygonStat;

	// Token: 0x0400E4DB RID: 58587
	private bool IsPlayerInFight;

	// Token: 0x0400E4DC RID: 58588
	private readonly Pool<PlayerPerceptionEvent> PerceptionEventPool;

	// Token: 0x0400E4DD RID: 58589
	private readonly Pool<PerceptionRange> PerceptionRangePool;

	// Token: 0x02009687 RID: 38535
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x04031ABD RID: 203453
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<PlayerPerceptionEvent> <0>__PerceptionEventCreator;

		// Token: 0x04031ABE RID: 203454
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Func<PerceptionRange> <1>__PerceptionRangeCreator;
	}
}
