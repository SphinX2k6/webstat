using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Game.World.Controller;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006001 RID: 24577
	[NullableContext(1)]
	[Nullable(0)]
	public class EavesdropMark : UiPanelBase
	{
		// Token: 0x0603DE4A RID: 253514 RVA: 0x00FC926C File Offset: 0x00FC746C
		public EavesdropMark(AActor trackActor, int entityId)
		{
			if (GlobalData.World == null)
			{
				return;
			}
			this.TrackingActor = trackActor;
			this.TrackingEntityId = new int?(entityId);
			Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
			if (entity == null)
			{
				return;
			}
			this.TargetTagComp = entity.GetComponent<BaseTagComponent>();
			this.TargetTagComp.AddTagAddOrRemoveListener(EavesdropMark.NormalTag, new BaseTagComponent.TTagSwitchedCallback(this.OnChangeToNormal), null);
			this.TargetTagComp.AddTagAddOrRemoveListener(EavesdropMark.StartTakingTag, new BaseTagComponent.TTagSwitchedCallback(this.OnStartTaking), null);
			this.TargetTagComp.AddTagAddOrRemoveListener(EavesdropMark.EndTag, new BaseTagComponent.TTagSwitchedCallback(this.OnGameplayEnd), null);
		}

		// Token: 0x0603DE4B RID: 253515 RVA: 0x00FC9334 File Offset: 0x00FC7534
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603DE4C RID: 253516 RVA: 0x00FC93E0 File Offset: 0x00FC75E0
		protected override void OnStart()
		{
			this.NormalItem = base.GetItem(0);
			this.DistText = base.GetText(1);
			this.TakingItem = base.GetItem(2);
			this.FoundItem = base.GetItem(3);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.SequenceFinishEvent), false);
			}
			UUIItem normalItem = this.NormalItem;
			if (normalItem != null)
			{
				normalItem.SetUIActive(true);
			}
			UUIItem takingItem = this.TakingItem;
			if (takingItem != null)
			{
				takingItem.SetUIActive(false);
			}
			UUIItem foundItem = this.FoundItem;
			if (foundItem != null)
			{
				foundItem.SetUIActive(false);
			}
			this.LevelSequencePlayer.PlaySequencePurely("Eavesdrop_Start", false, false, null, null, false);
			this.SeqState = EavesdropMark.ESeqState.Normal;
			this.MeshComp = (this.TrackingActor.GetComponentByClass(USkeletalMeshComponent.StaticClass()) as USkeletalMeshComponent);
			double? num = this.UpdateDistText();
			this.UpdateRotation();
			this.UpdateLocation();
			if (num != null && ControllerBase<SneakController>.Instance.IsSneaking)
			{
				double num2 = (double)this.ShowDist;
				double? num3 = num;
				if ((num2 < num3.GetValueOrDefault() & num3 != null) && !base.GetActive())
				{
					this.SetActive(true);
				}
				else
				{
					double num4 = (double)this.ShowDist;
					num3 = num;
					if ((num4 >= num3.GetValueOrDefault() & num3 != null) && base.GetActive())
					{
						this.SetActive(false);
					}
				}
			}
			UUIItem rootItem = this.RootItem;
			FVector fvector = Vector.Create(0.5, 0.5, 0.5).ToUeVectorOld();
			rootItem.SetUIRelativeScale3D(fvector);
		}

		// Token: 0x0603DE4D RID: 253517 RVA: 0x00FC9580 File Offset: 0x00FC7780
		public void Update()
		{
			double? num = this.UpdateDistText();
			this.UpdateRotation();
			this.UpdateLocation();
			if (num != null && ControllerBase<SneakController>.Instance.IsSneaking)
			{
				double num2 = (double)this.ShowDist;
				double? num3 = num;
				if ((num2 < num3.GetValueOrDefault() & num3 != null) && base.GetActive())
				{
					this.SetActive(false);
					return;
				}
				double num4 = (double)this.ShowDist;
				num3 = num;
				if ((num4 >= num3.GetValueOrDefault() & num3 != null) && !base.GetActive())
				{
					this.SetActive(true);
				}
			}
		}

		// Token: 0x0603DE4E RID: 253518 RVA: 0x00FC9610 File Offset: 0x00FC7810
		private void UpdateRotation()
		{
			Rotator cameraRotator = ControllerBase<CameraController>.Instance.MainModel.CameraRotator;
			float num = cameraRotator.Yaw + 90f;
			float num2 = cameraRotator.Pitch - 90f;
			Rotator rotator = Rotator.Create(this.RootItem.RelativeRotation);
			if (Math.Abs(num - this.RootActorRotation.Yaw) < 0.1f && Math.Abs(num2 - this.RootActorRotation.Roll) < 0.1f && rotator.Equals(this.RootActorRotation, 0.1f))
			{
				return;
			}
			this.RootActorRotation.Yaw = num;
			this.RootActorRotation.Pitch = 0f;
			this.RootActorRotation.Roll = num2;
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			FRotator frotator = this.RootActorRotation.ToUeRotator();
			rootItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x0603DE4F RID: 253519 RVA: 0x00FC96E8 File Offset: 0x00FC78E8
		private double? UpdateDistText()
		{
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Vector vector;
			if (baseCharacter == null)
			{
				vector = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				vector = ((characterActorComponent != null) ? characterActorComponent.ActorLocationProxy : null);
			}
			Vector vector2 = vector;
			AActor trackingActor = this.TrackingActor;
			FVectorDouble? fvectorDouble = (trackingActor != null) ? new FVectorDouble?(trackingActor.D_K2_GetActorLocation()) : null;
			if (vector2 != null && fvectorDouble != null)
			{
				Vector vector3 = Vector.Create(fvectorDouble).SubtractionEqual(Vector.Create(vector2));
				UUIText distText = this.DistText;
				if (distText != null)
				{
					distText.SetText(Math.Round(vector3.Size() / 100.0).ToString() + " 米", true);
				}
				return new double?(vector3.Size());
			}
			UUIText distText2 = this.DistText;
			if (distText2 != null)
			{
				distText2.SetText(string.Empty, true);
			}
			return null;
		}

		// Token: 0x0603DE50 RID: 253520 RVA: 0x00FC97C0 File Offset: 0x00FC79C0
		private void UpdateLocation()
		{
			FVectorDouble inVec = this.MeshComp.D_GetSocketLocation(EavesdropMark.HeadName);
			inVec.Z += 150.0;
			FVector uirelativeLocation = UKismetMathLibrary.Conv_VectorDoubleToVector(inVec);
			this.RootItem.SetUIRelativeLocation(uirelativeLocation);
		}

		// Token: 0x0603DE51 RID: 253521 RVA: 0x00FC9805 File Offset: 0x00FC7A05
		private void OnChangeToNormal(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Normal)
			{
				return;
			}
			this.PlayChangeToNormalSeq();
		}

		// Token: 0x0603DE52 RID: 253522 RVA: 0x00FC981A File Offset: 0x00FC7A1A
		private void OnStartTaking(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				return;
			}
			if (this.SeqState != EavesdropMark.ESeqState.Normal)
			{
				return;
			}
			this.PlayTakingSeq();
		}

		// Token: 0x0603DE53 RID: 253523 RVA: 0x00FC982F File Offset: 0x00FC7A2F
		private void OnGameplayEnd(int tagId, bool tagExist)
		{
			if (!tagExist)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.None)
			{
				return;
			}
			this.PlayEndSeq();
		}

		// Token: 0x0603DE54 RID: 253524 RVA: 0x00FC9848 File Offset: 0x00FC7A48
		public void PlayFoundSeq()
		{
			if (this.SeqState == EavesdropMark.ESeqState.Found)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Normal)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Eavesdrop_Close", false, false, null, null, false);
				}
				this.NextSeqState = EavesdropMark.ESeqState.Found;
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Taking)
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlaySequencePurely("Talk_Close", false, false, null, null, false);
				}
				this.NextSeqState = EavesdropMark.ESeqState.Found;
			}
		}

		// Token: 0x0603DE55 RID: 253525 RVA: 0x00FC98C8 File Offset: 0x00FC7AC8
		private void PlayFoundSeqInternal()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("BeFound_Start", false, false, null, null, false);
			}
			this.SeqState = EavesdropMark.ESeqState.Found;
			this.NextSeqState = EavesdropMark.ESeqState.None;
		}

		// Token: 0x0603DE56 RID: 253526 RVA: 0x00FC9908 File Offset: 0x00FC7B08
		private void PlayNormalSeqInternal()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Eavesdrop_Start", false, false, null, null, false);
			}
			this.SeqState = EavesdropMark.ESeqState.Normal;
			this.NextSeqState = EavesdropMark.ESeqState.None;
		}

		// Token: 0x0603DE57 RID: 253527 RVA: 0x00FC9948 File Offset: 0x00FC7B48
		public void PlayEndSeq()
		{
			if (this.SeqState == EavesdropMark.ESeqState.None)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Taking)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Talk_Close", false, false, null, null, false);
				}
			}
			else if (this.SeqState == EavesdropMark.ESeqState.Normal)
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlaySequencePurely("Eavesdrop_Close", false, false, null, null, false);
				}
			}
			this.SeqState = EavesdropMark.ESeqState.None;
		}

		// Token: 0x0603DE58 RID: 253528 RVA: 0x00FC99C0 File Offset: 0x00FC7BC0
		public void PlayTakingSeq()
		{
			if (this.SeqState == EavesdropMark.ESeqState.Taking)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Normal)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Eavesdrop_Close", false, false, null, null, false);
				}
				this.NextSeqState = EavesdropMark.ESeqState.Taking;
			}
		}

		// Token: 0x0603DE59 RID: 253529 RVA: 0x00FC9A0C File Offset: 0x00FC7C0C
		public void PlayChangeToNormalSeq()
		{
			if (this.SeqState == EavesdropMark.ESeqState.Normal)
			{
				return;
			}
			if (this.SeqState == EavesdropMark.ESeqState.Taking)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlaySequencePurely("Talk_Close", false, false, null, null, false);
				}
				this.NextSeqState = EavesdropMark.ESeqState.Normal;
			}
		}

		// Token: 0x0603DE5A RID: 253530 RVA: 0x00FC9A58 File Offset: 0x00FC7C58
		private void PlayTakingSeqInternal()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Talk_Start", false, false, null, null, false);
			}
			this.SeqState = EavesdropMark.ESeqState.Taking;
			this.NextSeqState = EavesdropMark.ESeqState.None;
		}

		// Token: 0x0603DE5B RID: 253531 RVA: 0x00FC9A98 File Offset: 0x00FC7C98
		private void SequenceFinishEvent(string sequenceName)
		{
			if (!(sequenceName == "Eavesdrop_Close") && !(sequenceName == "Talk_Close"))
			{
				if (sequenceName == "Talk_Start")
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlaySequencePurely("Loop", false, false, null, null, false);
				}
				return;
			}
			if (sequenceName == "Eavesdrop_Close")
			{
				UUIItem normalItem = this.NormalItem;
				if (normalItem != null)
				{
					normalItem.SetUIActive(false);
				}
			}
			else if (sequenceName == "Talk_Close")
			{
				UUIItem takingItem = this.TakingItem;
				if (takingItem != null)
				{
					takingItem.SetUIActive(false);
				}
			}
			switch (this.NextSeqState)
			{
			case EavesdropMark.ESeqState.Normal:
			{
				UUIItem normalItem2 = this.NormalItem;
				if (normalItem2 != null)
				{
					normalItem2.SetUIActive(true);
				}
				this.PlayNormalSeqInternal();
				return;
			}
			case EavesdropMark.ESeqState.Taking:
			{
				UUIItem takingItem2 = this.TakingItem;
				if (takingItem2 != null)
				{
					takingItem2.SetUIActive(true);
				}
				this.PlayTakingSeqInternal();
				return;
			}
			case EavesdropMark.ESeqState.Found:
			{
				UUIItem foundItem = this.FoundItem;
				if (foundItem != null)
				{
					foundItem.SetUIActive(true);
				}
				this.PlayFoundSeqInternal();
				return;
			}
			case EavesdropMark.ESeqState.None:
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RemoveEavesdropMark, this.TrackingEntityId.Value);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603DE5C RID: 253532 RVA: 0x00FC9BB8 File Offset: 0x00FC7DB8
		public void Initialize(UUIItem parent, float showDist)
		{
			base.CreateThenShowByResourceIdAsync("UiItem_Eavesdrop", parent, false).Forget();
			this.ShowDist = showDist;
			this.SetActive(ControllerBase<SneakController>.Instance.IsSneaking);
			Singleton<EventSystem>.Instance.Add(EEventName.SneakStart, new Action(this.OnSneakStart));
			Singleton<EventSystem>.Instance.Add(EEventName.SneakEnd, new Action(this.OnSneakEnd));
		}

		// Token: 0x0603DE5D RID: 253533 RVA: 0x00FC9C26 File Offset: 0x00FC7E26
		private void OnSneakStart()
		{
			this.SetActive(true);
		}

		// Token: 0x0603DE5E RID: 253534 RVA: 0x00FC9C2F File Offset: 0x00FC7E2F
		private void OnSneakEnd()
		{
			this.SetActive(false);
		}

		// Token: 0x0603DE5F RID: 253535 RVA: 0x00FC9C38 File Offset: 0x00FC7E38
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.SneakStart, new Action(this.OnSneakStart));
			Singleton<EventSystem>.Instance.Remove(EEventName.SneakEnd, new Action(this.OnSneakEnd));
		}

		// Token: 0x04022B6A RID: 142186
		private const float UPDATE_TOLERATION = 0.1f;

		// Token: 0x04022B6B RID: 142187
		private const float HEAD_OFFSET = 150f;

		// Token: 0x04022B6C RID: 142188
		private const string NORMAL_START = "Eavesdrop_Start";

		// Token: 0x04022B6D RID: 142189
		private const string NORMAL_END = "Eavesdrop_Close";

		// Token: 0x04022B6E RID: 142190
		private const string TAKING_START = "Talk_Start";

		// Token: 0x04022B6F RID: 142191
		private const string TAKING_LOOP = "Loop";

		// Token: 0x04022B70 RID: 142192
		private const string TAKING_END = "Talk_Close";

		// Token: 0x04022B71 RID: 142193
		private const string FOUND = "BeFound_Start";

		// Token: 0x04022B72 RID: 142194
		[StaticVariableRuleIgnore]
		private static readonly int NormalTag = GameplayTagDefine.EGameplayTagId["怪物.common.关卡.偷听玩法.常态"];

		// Token: 0x04022B73 RID: 142195
		[StaticVariableRuleIgnore]
		private static readonly int StartTakingTag = GameplayTagDefine.EGameplayTagId["怪物.common.关卡.偷听玩法.剧情中"];

		// Token: 0x04022B74 RID: 142196
		[StaticVariableRuleIgnore]
		private static readonly int EndTag = GameplayTagDefine.EGameplayTagId["怪物.common.关卡.偷听玩法.剧情结束"];

		// Token: 0x04022B75 RID: 142197
		[StaticVariableRuleIgnore]
		private static readonly FName HeadName = new FName("Bip001Head");

		// Token: 0x04022B76 RID: 142198
		[Nullable(2)]
		private readonly AActor TrackingActor;

		// Token: 0x04022B77 RID: 142199
		private readonly int? TrackingEntityId;

		// Token: 0x04022B78 RID: 142200
		[Nullable(2)]
		private readonly BaseTagComponent TargetTagComp;

		// Token: 0x04022B79 RID: 142201
		[Nullable(2)]
		private USkeletalMeshComponent MeshComp;

		// Token: 0x04022B7A RID: 142202
		[Nullable(2)]
		private UUIItem NormalItem;

		// Token: 0x04022B7B RID: 142203
		[Nullable(2)]
		private UUIText DistText;

		// Token: 0x04022B7C RID: 142204
		[Nullable(2)]
		private UUIItem TakingItem;

		// Token: 0x04022B7D RID: 142205
		[Nullable(2)]
		private UUIItem FoundItem;

		// Token: 0x04022B7E RID: 142206
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022B7F RID: 142207
		private readonly Rotator RootActorRotation = Rotator.Create();

		// Token: 0x04022B80 RID: 142208
		private EavesdropMark.ESeqState SeqState = EavesdropMark.ESeqState.None;

		// Token: 0x04022B81 RID: 142209
		private EavesdropMark.ESeqState NextSeqState = EavesdropMark.ESeqState.None;

		// Token: 0x04022B82 RID: 142210
		private float ShowDist = -1f;

		// Token: 0x0200C08B RID: 49291
		[NullableContext(0)]
		private enum EComponents
		{
			// Token: 0x0403B489 RID: 242825
			NormalItem,
			// Token: 0x0403B48A RID: 242826
			DistText,
			// Token: 0x0403B48B RID: 242827
			TakingItem,
			// Token: 0x0403B48C RID: 242828
			FoundItem
		}

		// Token: 0x0200C08C RID: 49292
		[NullableContext(0)]
		private enum ESeqState
		{
			// Token: 0x0403B48E RID: 242830
			Normal,
			// Token: 0x0403B48F RID: 242831
			Taking,
			// Token: 0x0403B490 RID: 242832
			Found,
			// Token: 0x0403B491 RID: 242833
			None
		}
	}
}
