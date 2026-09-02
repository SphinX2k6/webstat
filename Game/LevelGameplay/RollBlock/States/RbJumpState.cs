using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.States
{
	// Token: 0x02006B25 RID: 27429
	[NullableContext(2)]
	[Nullable(0)]
	public class RbJumpState : RbBaseMoveState
	{
		// Token: 0x06043C66 RID: 277606 RVA: 0x01181836 File Offset: 0x0117FA36
		[NullableContext(1)]
		public RbJumpState(RbBlockComponent owner) : base(owner)
		{
		}

		// Token: 0x06043C67 RID: 277607 RVA: 0x01181840 File Offset: 0x0117FA40
		public override void Enter([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> info)
		{
			if (!RollBlockDefind.isRbBlockJumpState(info))
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbJumpState Enter without JumpState info", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.StateName = ERollBlockMoveState.Jump;
			this.Info = info.AsT2;
			if (this.DirectorActor == null)
			{
				this.GenerateStaticDirector();
			}
			if (this.DirectorActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbJumpState Enter DirectorActor create failed", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			if (this.DirectorActor.SequencePlayer.IsPlaying())
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbJumpState Enter but DirectorActor is playing", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			UDefaultLevelSequenceInstanceData udefaultLevelSequenceInstanceData = this.DirectorActor.DefaultInstanceData as UDefaultLevelSequenceInstanceData;
			FTransformDouble transform = this.Owner.Transform;
			global::Vector vector = this.Owner.PbDirToVector(this.Info.Direction);
			global::Rotator rotator = global::Rotator.Create();
			vector.Rotation(rotator);
			FRotator frotator = rotator.ToUeRotator();
			FQuat fquat = new FQuat(ref frotator);
			transform.SetRotation(fquat);
			udefaultLevelSequenceInstanceData.TransformOrigin = UKismetMathLibrary.Conv_TransformDoubleToTransform(transform);
			udefaultLevelSequenceInstanceData.ApplyWorldOrigin = true;
			Singleton<ResourceSystem>.Instance.LoadAsync<ULevelSequence>("/Game/Aki/Data/Gameplay/RollBlock/Sequence/RollBlockJump.RollBlockJump", delegate([Nullable(2)] ULevelSequence seq, string _)
			{
				AActor actor = this.Owner.GetActor();
				if (actor == null)
				{
					Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbJumpState Enter without Owner Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
					return;
				}
				this.DirectorActor.SetActorTickEnabled(true);
				this.DirectorActor.SetSequence(seq);
				this.DirectorActor.SequencePlayer.OnFinished.Clear();
				this.DirectorActor.AddBindingByTag(RollBlockDefind.RB_SEQ_BINDING_TAG, actor, false, false);
				if (this.DirectorActor.SequencePlayer == null || !this.DirectorActor.SequencePlayer.IsValid())
				{
					Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbJumpState Enter without SequencePlayer", default(ReadOnlySpan<ValueTuple<string, object>>));
					this.OnSeqEnd(false);
					return;
				}
				this.DirectorActor.SequencePlayer.SetPlayRate(1f);
				this.DirectorActor.SequencePlayer.Play();
				this.DirectorActor.SequencePlayer.OnFinished.Add(delegate()
				{
					this.OnSeqEnd(true);
				});
			}, 100, "js_undefined");
			this.IsFinishedInternal = false;
		}

		// Token: 0x06043C68 RID: 277608 RVA: 0x01181984 File Offset: 0x0117FB84
		private void GenerateStaticDirector()
		{
			if (this.DirectorActor == null)
			{
				this.DirectorActor = (Singleton<ActorSystem>.Instance.Get(ALevelSequenceActor.StaticClass(), Singleton<MathUtils>.Instance.DefaultTransformDouble, null, false) as ALevelSequenceActor);
				this.DirectorActor.bOverrideInstanceData = true;
			}
		}

		// Token: 0x06043C69 RID: 277609 RVA: 0x011819C0 File Offset: 0x0117FBC0
		private void OnSeqEnd(bool needNotify = false)
		{
			this.DirectorActor.SetActorTickEnabled(false);
			this.DirectorActor.SetSequence(null);
			this.DirectorActor.RemoveBindingByTag(RollBlockDefind.RB_SEQ_BINDING_TAG, this.Owner.GetActor(), false);
			this.DirectorActor.SequencePlayer.OnFinished.Clear();
			if (needNotify && ControllerBase<RollBlockController>.Instance.IsCurrentIncId(this.Owner.IncId))
			{
				base.NotifyServerMovementFinish();
			}
			this.IsFinishedInternal = true;
		}

		// Token: 0x04025E76 RID: 155254
		public RbJumpMovement Info;

		// Token: 0x04025E77 RID: 155255
		private ALevelSequenceActor DirectorActor;
	}
}
