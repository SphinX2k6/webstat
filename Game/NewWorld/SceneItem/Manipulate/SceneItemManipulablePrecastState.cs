using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.SceneItem.Manipulate
{
	// Token: 0x0200485A RID: 18522
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemManipulablePrecastState : SceneItemManipulableBaseState
	{
		// Token: 0x060302E9 RID: 197353 RVA: 0x00BB22A6 File Offset: 0x00BB04A6
		public SceneItemManipulablePrecastState(SceneItemManipulatableComponent sceneItem) : base(sceneItem)
		{
		}

		// Token: 0x060302EA RID: 197354 RVA: 0x00BB22C5 File Offset: 0x00BB04C5
		public void SetDirection(int newValue)
		{
			this.Direction = newValue;
		}

		// Token: 0x060302EB RID: 197355 RVA: 0x00BB22CE File Offset: 0x00BB04CE
		protected override void OnEnter()
		{
			this.Timer = 0f;
			this.CurrentPrecastSpline = ConfigBase<ManipulateConfig>.Instance.ManipulatePrecastLines[this.Direction];
			this.StartActorLoc = Vector.Create(this.SceneItem.ActorComp.ActorLocationProxy);
		}

		// Token: 0x060302EC RID: 197356 RVA: 0x00BB2310 File Offset: 0x00BB0510
		protected override void OnTick(float delta)
		{
			this.Timer += delta * 1000f;
			FVector? precastLineValue = ConfigBase<ManipulateConfig>.Instance.GetPrecastLineValue(this.CurrentPrecastSpline, this.Timer / ConfigBase<ManipulateConfig>.Instance.PrecastTime);
			Vector vector = Vector.Create();
			Vector vector2 = Vector.Create();
			Vector targetLocation = this.GetTargetLocation();
			this.CalcCharacterDirs();
			this.CharacterDir.Multiply((double)precastLineValue.Value.X, vector);
			this.CharacterVerticalDir.Multiply((double)precastLineValue.Value.Z, vector2);
			vector2.AdditionEqual(vector);
			vector2.AdditionEqual(targetLocation);
			this.SceneItem.ActorComp.SetActorLocation(vector2.ToUeVector(false), "unknown", true);
		}

		// Token: 0x060302ED RID: 197357 RVA: 0x00BB23D0 File Offset: 0x00BB05D0
		private Vector GetTargetLocation()
		{
			FTransformDouble actorTransform = Global.BaseCharacter.CharacterActorComponent.ActorTransform;
			FVectorDouble value = (this.SceneItem.UsingAssistantHoldOffset ? this.SceneItem.ConfigAssistantHoldOffset : this.SceneItem.ConfigHoldOffset).Value;
			Vector vector = Vector.Create(actorTransform.TransformPositionNoScale(value));
			if (this.StartActorLoc != null)
			{
				float num = Singleton<MathUtils>.Instance.Clamp(this.Timer / ConfigBase<ManipulateConfig>.Instance.PrecastTime, 0f, 1f);
				if (num < 1f)
				{
					Vector vector2 = Vector.Create();
					vector.Subtraction(this.StartActorLoc, vector2);
					Vector vector3 = Vector.Create();
					vector2.Multiply((double)num, vector3);
					Vector vector4 = Vector.Create(this.StartActorLoc);
					vector4.AdditionEqual(vector3);
					return vector4;
				}
			}
			return vector;
		}

		// Token: 0x060302EE RID: 197358 RVA: 0x00BB24A8 File Offset: 0x00BB06A8
		private void CalcCharacterDirs()
		{
			Vector vector = Vector.Create();
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Vector characterDir;
			if (baseCharacter == null)
			{
				characterDir = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
				characterDir = ((characterActorComponent != null) ? characterActorComponent.ActorForwardProxy : null);
			}
			this.CharacterDir = characterDir;
			TsBaseCharacter baseCharacter2 = Global.BaseCharacter;
			Vector vector2;
			if (baseCharacter2 == null)
			{
				vector2 = null;
			}
			else
			{
				CharacterActorComponent characterActorComponent2 = baseCharacter2.CharacterActorComponent;
				vector2 = ((characterActorComponent2 != null) ? characterActorComponent2.ActorUpProxy : null);
			}
			Vector inB = vector2;
			this.CharacterDir.CrossProduct(inB, vector);
			vector.CrossProduct(this.CharacterDir, this.CharacterVerticalDir);
			this.CharacterVerticalDir.Normalize(9.99999993922529E-09);
		}

		// Token: 0x0401BAA0 RID: 113312
		private int Direction;

		// Token: 0x0401BAA1 RID: 113313
		private string CurrentPrecastSpline = "";

		// Token: 0x0401BAA2 RID: 113314
		[Nullable(2)]
		private Vector CharacterDir;

		// Token: 0x0401BAA3 RID: 113315
		private readonly Vector CharacterVerticalDir = Vector.Create();

		// Token: 0x0401BAA4 RID: 113316
		[Nullable(2)]
		private Vector StartActorLoc;
	}
}
