using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002368 RID: 9064
[NullableContext(1)]
[Nullable(0)]
public class PanoramicPointView : UiPanelBase
{
	// Token: 0x0601157C RID: 71036 RVA: 0x004C6894 File Offset: 0x004C4A94
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
		}
	}

	// Token: 0x0601157D RID: 71037 RVA: 0x004C6924 File Offset: 0x004C4B24
	protected override void OnStart()
	{
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		this.LimitA = Math.Min(1176f, (((uiRootItem != null) ? uiRootItem.GetWidth() : 0f) - 1008f) / 2f);
		this.LimitB = Math.Min(712.5f, (((uiRootItem != null) ? uiRootItem.GetHeight() : 0f) - 495f) / 2f);
		UUIItem rootItem = this.RootItem;
		if (rootItem != null)
		{
			rootItem.SetUIActive(true);
		}
		this.SprArrow = base.GetItem(1);
		UUIItem sprArrow = this.SprArrow;
		if (sprArrow != null)
		{
			sprArrow.SetUIActive(false);
		}
		InputMultiKeyItem keyItem = this.KeyItem;
		if (keyItem != null)
		{
			keyItem.SetUiActive(false);
		}
		this.SeqPlayer = new LevelSequencePlayer(this.RootItem);
		this.LastScreenPosition.Reset();
		this.ScreenPosition.Reset();
		UUIItem rootItem2 = this.RootItem;
		if (rootItem2 != null)
		{
			rootItem2.ResetRelativeTransform();
		}
		UUIItem rootItem3 = this.RootItem;
		if (rootItem3 != null)
		{
			rootItem3.SetAnchorOffset(new FVector2D(0f, 0f));
		}
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			UUIItem rootItem4 = this.RootItem;
			if (rootItem4 != null)
			{
				UUIItem parentAsUIItem = rootItem4.GetParentAsUIItem();
				if (parentAsUIItem != null)
				{
					FRotator frotator = new FRotator(0f, 0f, 0f);
					parentAsUIItem.SetUIRelativeRotation(frotator);
				}
			}
		}
		this.ViewType = EPanoramicType.Default;
	}

	// Token: 0x0601157E RID: 71038 RVA: 0x004C6A78 File Offset: 0x004C4C78
	protected override UniTask OnBeforeStartAsync()
	{
		PanoramicPointView.<OnBeforeStartAsync>d__19 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<PanoramicPointView.<OnBeforeStartAsync>d__19>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601157F RID: 71039 RVA: 0x004C6ABB File Offset: 0x004C4CBB
	protected override void OnAfterShow()
	{
	}

	// Token: 0x06011580 RID: 71040 RVA: 0x004C6ABD File Offset: 0x004C4CBD
	[NullableContext(2)]
	public void DestroySelf(Action callback)
	{
		LevelSequencePlayer seqPlayer = this.SeqPlayer;
		if (seqPlayer != null)
		{
			seqPlayer.StopCurrentSequence(false, false);
		}
		if (callback != null)
		{
			callback();
		}
	}

	// Token: 0x06011581 RID: 71041 RVA: 0x004C6ADC File Offset: 0x004C4CDC
	public void Update()
	{
		TsCharacterController characterController = Global.CharacterController;
		FVectorDouble fvectorDouble = this.TargetPos.ToUeVector(false);
		FVector2D screenPositionRef = this.ScreenPositionRef;
		bool flag = UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble, ref screenPositionRef, false);
		if (!flag)
		{
			FTransformDouble? cameraTransform = ModelBase<CameraModel>.Instance.MainModel.CameraTransform;
			if (cameraTransform != null)
			{
				FVectorDouble fvectorDouble2 = cameraTransform.Value.InverseTransformPositionNoScale(fvectorDouble);
				fvectorDouble2.X = -fvectorDouble2.X;
				FVectorDouble fvectorDouble3 = cameraTransform.Value.TransformPositionNoScale(fvectorDouble2);
				UGameplayStatics.D_ProjectWorldToScreen(characterController, fvectorDouble3, ref screenPositionRef, false);
			}
		}
		FVector2D fvector2D = screenPositionRef;
		this.ScreenPosition.Set((double)fvector2D.X, (double)fvector2D.Y);
		if (!this.LastScreenPosition.Equals(this.ScreenPosition, 1.0))
		{
			this.LastScreenPosition.DeepCopy(this.ScreenPosition);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			this.ScreenPosition.MultiplyEqual((double)((instance != null) ? instance.ScreenPositionScale : 0f)).AdditionEqual(((instance != null) ? instance.ScreenPositionOffset : null) ?? null).MultiplyEqual(this.PointTransport);
			this.InRange = this.ClampToEllipse(this.ScreenPosition, flag);
			Vector2D vector2D = this.ScreenPosition.AdditionEqual(this.center);
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorOffset(vector2D.ToUeVector2D(false));
			}
			if (!this.InRange)
			{
				if (ControllerBase<PanoramicController>.Instance.CheckDisablePanoramic())
				{
					if (this.RootItem.bIsUIActive)
					{
						this.RootItem.SetUIActive(false);
					}
				}
				else if (!this.RootItem.bIsUIActive)
				{
					this.RootItem.SetUIActive(true);
				}
				this.TempRotator.Reset();
				this.TempRotator.Yaw = (float)Math.Atan2(this.ScreenPosition.Y, this.ScreenPosition.X) * 57.295776f;
				if (this.SprArrow != null)
				{
					UUIItem sprArrow = this.SprArrow;
					FRotator frotator = this.TempRotator.ToUeRotator();
					sprArrow.SetUIRelativeRotation(frotator);
					this.SprArrow.SetUIActive(true);
					return;
				}
			}
			else
			{
				if (!this.RootItem.bIsUIActive)
				{
					this.RootItem.SetUIActive(true);
				}
				UUIItem sprArrow2 = this.SprArrow;
				if (sprArrow2 == null)
				{
					return;
				}
				sprArrow2.SetUIActive(false);
			}
		}
	}

	// Token: 0x06011582 RID: 71042 RVA: 0x004C6D24 File Offset: 0x004C4F24
	[NullableContext(2)]
	public void SetTargetPos(Vector offset)
	{
		this.TargetPos.X = ((offset != null) ? offset.X : 0.0);
		this.TargetPos.Y = ((offset != null) ? offset.Y : 0.0);
		this.TargetPos.Z = ((offset != null) ? offset.Z : 0.0);
	}

	// Token: 0x06011583 RID: 71043 RVA: 0x004C6D90 File Offset: 0x004C4F90
	protected bool ClampToEllipse(Vector2D vector, bool inFront)
	{
		double x = vector.X;
		double y = vector.Y;
		float limitA = this.LimitA;
		float limitB = this.LimitB;
		if (inFront && x * x / (double)(limitA * limitA) + y * y / (double)(limitB * limitB) <= 1.0)
		{
			return true;
		}
		double inB = (double)(limitA * limitB) / Math.Sqrt((double)(limitB * limitB) * x * x + (double)(limitA * limitA) * y * y);
		vector.MultiplyEqual(inB);
		return false;
	}

	// Token: 0x06011584 RID: 71044 RVA: 0x004C6E04 File Offset: 0x004C5004
	public void ChangePointType(EPanoramicType type)
	{
		if (this.ViewType == type)
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				if (this.ViewType == EPanoramicType.Active)
				{
					InputMultiKeyItem keyItem = this.KeyItem;
					if (keyItem == null || !keyItem.GetActive())
					{
						InputMultiKeyItem keyItem2 = this.KeyItem;
						if (keyItem2 == null)
						{
							return;
						}
						keyItem2.SetUiActive(true);
						return;
					}
				}
				else
				{
					InputMultiKeyItem keyItem3 = this.KeyItem;
					if (keyItem3 != null && keyItem3.GetActive())
					{
						InputMultiKeyItem keyItem4 = this.KeyItem;
						if (keyItem4 == null)
						{
							return;
						}
						keyItem4.SetUiActive(false);
					}
				}
			}
			return;
		}
		switch (type)
		{
		case EPanoramicType.Default:
			switch (this.ViewType)
			{
			case EPanoramicType.Active:
			{
				LevelSequencePlayer seqPlayer = this.SeqPlayer;
				if (seqPlayer != null)
				{
					seqPlayer.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer2 = this.SeqPlayer;
				if (seqPlayer2 != null)
				{
					seqPlayer2.PlayLevelSequenceByName("AtoB", false, null, false);
				}
				break;
			}
			case EPanoramicType.Ban:
			{
				LevelSequencePlayer seqPlayer3 = this.SeqPlayer;
				if (seqPlayer3 != null)
				{
					seqPlayer3.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer4 = this.SeqPlayer;
				if (seqPlayer4 != null)
				{
					seqPlayer4.PlayLevelSequenceByName("DtoB", false, null, false);
				}
				break;
			}
			}
			break;
		case EPanoramicType.Active:
			switch (this.ViewType)
			{
			case EPanoramicType.Default:
			{
				LevelSequencePlayer seqPlayer5 = this.SeqPlayer;
				if (seqPlayer5 != null)
				{
					seqPlayer5.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer6 = this.SeqPlayer;
				if (seqPlayer6 != null)
				{
					seqPlayer6.PlayLevelSequenceByName("BtoA", false, null, false);
				}
				break;
			}
			case EPanoramicType.Ban:
			{
				LevelSequencePlayer seqPlayer7 = this.SeqPlayer;
				if (seqPlayer7 != null)
				{
					seqPlayer7.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer8 = this.SeqPlayer;
				if (seqPlayer8 != null)
				{
					seqPlayer8.PlayLevelSequenceByName("DtoA", false, null, false);
				}
				break;
			}
			}
			break;
		case EPanoramicType.Ban:
			switch (this.ViewType)
			{
			case EPanoramicType.Default:
			{
				LevelSequencePlayer seqPlayer9 = this.SeqPlayer;
				if (seqPlayer9 != null)
				{
					seqPlayer9.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer10 = this.SeqPlayer;
				if (seqPlayer10 != null)
				{
					seqPlayer10.PlayLevelSequenceByName("BtoD", false, null, false);
				}
				break;
			}
			case EPanoramicType.Active:
			{
				LevelSequencePlayer seqPlayer11 = this.SeqPlayer;
				if (seqPlayer11 != null)
				{
					seqPlayer11.StopCurrentSequence(false, false);
				}
				LevelSequencePlayer seqPlayer12 = this.SeqPlayer;
				if (seqPlayer12 != null)
				{
					seqPlayer12.PlayLevelSequenceByName("AtoD", false, null, false);
				}
				break;
			}
			}
			break;
		}
		this.ViewType = type;
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			if (this.ViewType == EPanoramicType.Active)
			{
				InputMultiKeyItem keyItem5 = this.KeyItem;
				if (keyItem5 == null)
				{
					return;
				}
				keyItem5.SetUiActive(true);
				return;
			}
			else
			{
				InputMultiKeyItem keyItem6 = this.KeyItem;
				if (keyItem6 == null)
				{
					return;
				}
				keyItem6.SetUiActive(false);
			}
		}
	}

	// Token: 0x04008842 RID: 34882
	private const float CENTER_Y = 62.5f;

	// Token: 0x04008843 RID: 34883
	private Vector2D center = Vector2D.Create(0.0, 62.5);

	// Token: 0x04008844 RID: 34884
	[Nullable(2)]
	private UUIItem SprArrow;

	// Token: 0x04008845 RID: 34885
	[Nullable(2)]
	private InputMultiKeyItem KeyItem;

	// Token: 0x04008846 RID: 34886
	protected readonly FVector2D ScreenPositionRef = new FVector2D();

	// Token: 0x04008847 RID: 34887
	[Nullable(2)]
	private LevelSequencePlayer SeqPlayer;

	// Token: 0x04008848 RID: 34888
	private readonly Vector TargetPos = Vector.Create();

	// Token: 0x04008849 RID: 34889
	protected readonly Vector2D ScreenPosition = Vector2D.Create();

	// Token: 0x0400884A RID: 34890
	private readonly Vector2D LastScreenPosition = Vector2D.Create();

	// Token: 0x0400884B RID: 34891
	private readonly Rotator TempRotator = Rotator.Create();

	// Token: 0x0400884C RID: 34892
	private float LimitA;

	// Token: 0x0400884D RID: 34893
	private float LimitB;

	// Token: 0x0400884E RID: 34894
	private bool InRange;

	// Token: 0x0400884F RID: 34895
	private readonly Vector2D PointTransport = Vector2D.Create(1.0, -1.0);

	// Token: 0x04008850 RID: 34896
	private EPanoramicType ViewType;

	// Token: 0x04008851 RID: 34897
	public int Id = -1;

	// Token: 0x0200867E RID: 34430
	[NullableContext(0)]
	private class EPanoramicViewDefine
	{
		// Token: 0x0402D7F6 RID: 186358
		public const int PanelOffset = 0;

		// Token: 0x0402D7F7 RID: 186359
		public const int SprArrow = 1;

		// Token: 0x0402D7F8 RID: 186360
		public const int KeyPanel = 2;
	}
}
