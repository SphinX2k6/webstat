using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012F3 RID: 4851
[NullableContext(1)]
[Nullable(0)]
public class DangoMonopolyGridInfoPanel : UiPanelBase
{
	// Token: 0x0600835E RID: 33630 RVA: 0x0022B184 File Offset: 0x00229384
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public UniTask<DangoMonopolyGridInfoPanel> Init(DangoMonopolyGridData gridData, ActivityDangoMonopolyData data)
	{
		DangoMonopolyGridInfoPanel.<Init>d__7 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder<DangoMonopolyGridInfoPanel>.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.gridData = gridData;
		<Init>d__.data = data;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<Init>d__7>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600835F RID: 33631 RVA: 0x0022B1D7 File Offset: 0x002293D7
	public void UpdateGridData(DangoMonopolyGridData gridData)
	{
		this.GridData = gridData;
		this.UpdateData();
		this.CheckCompletedStateToEnd();
	}

	// Token: 0x06008360 RID: 33632 RVA: 0x0022B1EC File Offset: 0x002293EC
	protected override void OnBeforeCreate()
	{
	}

	// Token: 0x06008361 RID: 33633 RVA: 0x0022B1F0 File Offset: 0x002293F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x06008362 RID: 33634 RVA: 0x0022B2B8 File Offset: 0x002294B8
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyGridInfoPanel.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008363 RID: 33635 RVA: 0x0022B2FB File Offset: 0x002294FB
	protected override void OnStart()
	{
		this.RootActorRotation = new FRotator?(this.RootActor.K2_GetActorRotation());
		UUIText text = base.GetText(6);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew("DangoMonopoly_title_19");
	}

	// Token: 0x06008364 RID: 33636 RVA: 0x0022B329 File Offset: 0x00229529
	protected override void OnBeforeShow()
	{
		this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.TimerUpdate), 20f, 1f, null, null, true);
	}

	// Token: 0x06008365 RID: 33637 RVA: 0x0022B354 File Offset: 0x00229554
	protected override void OnBeforeHide()
	{
		this.ClearTimerHandle();
	}

	// Token: 0x06008366 RID: 33638 RVA: 0x0022B35C File Offset: 0x0022955C
	protected override void OnBeforeDestroy()
	{
		this.ClearTimerHandle();
	}

	// Token: 0x06008367 RID: 33639 RVA: 0x0022B364 File Offset: 0x00229564
	public void ClearTimerHandle()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06008368 RID: 33640 RVA: 0x0022B388 File Offset: 0x00229588
	public void UpdateData()
	{
		DangoMonopolyGridData gridData = this.GridData;
		if (gridData.IsExistItem())
		{
			this.UpdateItemInfo();
			return;
		}
		if (gridData.IsExistDango())
		{
			this.UpdateDangoInfo();
			return;
		}
		this.UpdateEmptyInfo();
	}

	// Token: 0x06008369 RID: 33641 RVA: 0x0022B3C0 File Offset: 0x002295C0
	public void CheckCompletedStateToEnd()
	{
		if (this.GridData.IsFinish())
		{
			LevelSequencePlayer sequence = this.Sequence;
			if (sequence != null)
			{
				sequence.PlayLevelSequenceByName("Done", false, null, false);
			}
			LevelSequencePlayer sequence2 = this.Sequence;
			if (sequence2 == null)
			{
				return;
			}
			sequence2.EndSequenceLastFrame("Done");
		}
	}

	// Token: 0x0600836A RID: 33642 RVA: 0x0022B410 File Offset: 0x00229610
	public void UpdateItemInfo()
	{
		DangoMonopolyGridData gridData = this.GridData;
		bool flag = gridData.IsActiveDouble();
		UUIItem item = base.GetItem(0);
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIItem item2 = base.GetItem(5);
		if (item2 != null)
		{
			item2.SetUIActive(flag);
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("X");
		defaultInterpolatedStringHandler.AppendFormatted<int>(flag ? (gridData.ItemCount * 2) : gridData.ItemCount);
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.SetText(newText, true);
		}
		bool uiactive = gridData.IsFinish();
		UUIItem item3 = base.GetItem(2);
		if (item3 != null)
		{
			item3.SetUIActive(uiactive);
		}
		int itemId = gridData.ItemId;
		InventoryConfig instance = ConfigBase<InventoryConfig>.Instance;
		ItemConfig itemConfig = (instance != null) ? instance.GetItemConfigData(itemId) : null;
		if (itemConfig != null)
		{
			string icon = itemConfig.Icon;
			base.SetTextureByPath(icon, base.GetTexture(3), null, null);
		}
	}

	// Token: 0x0600836B RID: 33643 RVA: 0x0022B4FA File Offset: 0x002296FA
	public void UpdateDangoInfo()
	{
		this.SetActive(false);
	}

	// Token: 0x0600836C RID: 33644 RVA: 0x0022B503 File Offset: 0x00229703
	public void UpdateEmptyInfo()
	{
		this.SetActive(false);
	}

	// Token: 0x0600836D RID: 33645 RVA: 0x0022B50C File Offset: 0x0022970C
	public UniTask EnterStartGridUpdate()
	{
		DangoMonopolyGridInfoPanel.<EnterStartGridUpdate>d__22 <EnterStartGridUpdate>d__;
		<EnterStartGridUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EnterStartGridUpdate>d__.<>4__this = this;
		<EnterStartGridUpdate>d__.<>1__state = -1;
		<EnterStartGridUpdate>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<EnterStartGridUpdate>d__22>(ref <EnterStartGridUpdate>d__);
		return <EnterStartGridUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0600836E RID: 33646 RVA: 0x0022B550 File Offset: 0x00229750
	public UniTask EnterEndGirdUpdate()
	{
		DangoMonopolyGridInfoPanel.<EnterEndGirdUpdate>d__23 <EnterEndGirdUpdate>d__;
		<EnterEndGirdUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<EnterEndGirdUpdate>d__.<>4__this = this;
		<EnterEndGirdUpdate>d__.<>1__state = -1;
		<EnterEndGirdUpdate>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<EnterEndGirdUpdate>d__23>(ref <EnterEndGirdUpdate>d__);
		return <EnterEndGirdUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x0600836F RID: 33647 RVA: 0x0022B594 File Offset: 0x00229794
	public UniTask OutBeforeGridUpdate()
	{
		DangoMonopolyGridInfoPanel.<OutBeforeGridUpdate>d__24 <OutBeforeGridUpdate>d__;
		<OutBeforeGridUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OutBeforeGridUpdate>d__.<>4__this = this;
		<OutBeforeGridUpdate>d__.<>1__state = -1;
		<OutBeforeGridUpdate>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<OutBeforeGridUpdate>d__24>(ref <OutBeforeGridUpdate>d__);
		return <OutBeforeGridUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x06008370 RID: 33648 RVA: 0x0022B5D8 File Offset: 0x002297D8
	public UniTask OutStartGridUpdate()
	{
		DangoMonopolyGridInfoPanel.<OutStartGridUpdate>d__25 <OutStartGridUpdate>d__;
		<OutStartGridUpdate>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OutStartGridUpdate>d__.<>4__this = this;
		<OutStartGridUpdate>d__.<>1__state = -1;
		<OutStartGridUpdate>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<OutStartGridUpdate>d__25>(ref <OutStartGridUpdate>d__);
		return <OutStartGridUpdate>d__.<>t__builder.Task;
	}

	// Token: 0x06008371 RID: 33649 RVA: 0x0022B61C File Offset: 0x0022981C
	public UniTask PlaySequence(string name)
	{
		DangoMonopolyGridInfoPanel.<PlaySequence>d__26 <PlaySequence>d__;
		<PlaySequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlaySequence>d__.<>4__this = this;
		<PlaySequence>d__.name = name;
		<PlaySequence>d__.<>1__state = -1;
		<PlaySequence>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<PlaySequence>d__26>(ref <PlaySequence>d__);
		return <PlaySequence>d__.<>t__builder.Task;
	}

	// Token: 0x06008372 RID: 33650 RVA: 0x0022B668 File Offset: 0x00229868
	public UniTask PlayActiveSequence()
	{
		DangoMonopolyGridInfoPanel.<PlayActiveSequence>d__27 <PlayActiveSequence>d__;
		<PlayActiveSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayActiveSequence>d__.<>4__this = this;
		<PlayActiveSequence>d__.<>1__state = -1;
		<PlayActiveSequence>d__.<>t__builder.Start<DangoMonopolyGridInfoPanel.<PlayActiveSequence>d__27>(ref <PlayActiveSequence>d__);
		return <PlayActiveSequence>d__.<>t__builder.Task;
	}

	// Token: 0x06008373 RID: 33651 RVA: 0x0022B6AC File Offset: 0x002298AC
	public void UpdateRotation(float yaw, float pitch)
	{
		if (this.RootActorRotation == null)
		{
			return;
		}
		float num = pitch - 90f;
		float num2 = yaw + 90f;
		double value = 0.001;
		bool flag = Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.RootActorRotation.Value.Roll, (double)num, new double?(value));
		bool flag2 = Singleton<MathUtils>.Instance.IsNearlyEqual((double)this.RootActorRotation.Value.Yaw, (double)num2, new double?(value));
		if (flag && flag2)
		{
			return;
		}
		this.RootActorRotation = new FRotator?(new FRotator(0f, num2, num));
		UUIItem rootItem = this.RootItem;
		FRotator value2 = this.RootActorRotation.Value;
		rootItem.SetUIWorldRotation(value2);
	}

	// Token: 0x06008374 RID: 33652 RVA: 0x0022B760 File Offset: 0x00229960
	public void UpdateCameraFace()
	{
		Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
		if (cameraRotator != null)
		{
			this.UpdateRotation(cameraRotator.Yaw, cameraRotator.Pitch);
		}
	}

	// Token: 0x06008375 RID: 33653 RVA: 0x0022B792 File Offset: 0x00229992
	public void TimerUpdate(float _)
	{
		this.UpdateCameraFace();
	}

	// Token: 0x06008376 RID: 33654 RVA: 0x0022B79C File Offset: 0x0022999C
	public void UpdateHeight()
	{
		int id = this.GridData.Id;
		IChessboardPointParams chessboardPointParams;
		if (!this.ActivityData.ChessPointParamsMap.TryGetValue(id, out chessboardPointParams))
		{
			return;
		}
		FVectorDouble newLocation = Vector.Create(chessboardPointParams.Location.X, chessboardPointParams.Location.Y, (double)this.ActivityData.GetGridEntityInfoAddHeight(id, (float)chessboardPointParams.Location.Z)).ToUeVector(false);
		FHitResult fhitResult = new FHitResult();
		base.GetRootItem().D_K2_SetWorldLocation(newLocation, true, ref fhitResult, false);
	}

	// Token: 0x06008377 RID: 33655 RVA: 0x0022B81C File Offset: 0x00229A1C
	public FVector2D GetCursorPosition()
	{
		UUIItem item = base.GetItem(7);
		return Singleton<UiModelUtil>.Instance.GetActorLguiPos(item.GetOwner(), null);
	}

	// Token: 0x04003E78 RID: 15992
	public DangoMonopolyGridData GridData;

	// Token: 0x04003E79 RID: 15993
	[Nullable(2)]
	public CustomPromise<bool> Promise;

	// Token: 0x04003E7A RID: 15994
	protected FRotator? RootActorRotation;

	// Token: 0x04003E7B RID: 15995
	[Nullable(2)]
	public TimerHandle TimerHandle;

	// Token: 0x04003E7C RID: 15996
	[Nullable(2)]
	public LevelSequencePlayer Sequence;

	// Token: 0x04003E7D RID: 15997
	public ActivityDangoMonopolyData ActivityData;

	// Token: 0x0200766C RID: 30316
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028CEA RID: 167146
		ItemTag,
		// Token: 0x04028CEB RID: 167147
		TxtTitle,
		// Token: 0x04028CEC RID: 167148
		ItemCompleted,
		// Token: 0x04028CED RID: 167149
		TextureIcon,
		// Token: 0x04028CEE RID: 167150
		ItemEffectNormal,
		// Token: 0x04028CEF RID: 167151
		ItemEffectDouble,
		// Token: 0x04028CF0 RID: 167152
		TxtTag,
		// Token: 0x04028CF1 RID: 167153
		ItemCursor
	}
}
