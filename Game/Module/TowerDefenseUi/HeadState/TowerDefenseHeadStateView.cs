using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TowerDefenseUi.HeadState
{
	// Token: 0x02004E7F RID: 20095
	[NullableContext(1)]
	[Nullable(0)]
	public class TowerDefenseHeadStateView : UiPanelBase
	{
		// Token: 0x06033EA8 RID: 212648 RVA: 0x00CFE380 File Offset: 0x00CFC580
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06033EA9 RID: 212649 RVA: 0x00CFE40A File Offset: 0x00CFC60A
		protected override void OnStart()
		{
			this.HpBarSprite = base.GetSprite(0);
			this.HpBarBufferSprite = base.GetSprite(1);
			this.ShieldBarSprite = base.GetSprite(2);
			this.InitUvModifier();
		}

		// Token: 0x06033EAA RID: 212650 RVA: 0x00CFE43C File Offset: 0x00CFC63C
		private void InitUvModifier()
		{
			foreach (UActorComponent uactorComponent in ULGUIBPLibrary.GetComponentsInChildrenWithHirerarchyIndex(this.RootActor, UUITextAdditionalUVModifier.StaticClass(), false))
			{
				this.UvModifierList.Add(uactorComponent as UUITextAdditionalUVModifier);
			}
		}

		// Token: 0x06033EAB RID: 212651 RVA: 0x00CFE4A4 File Offset: 0x00CFC6A4
		public void Refresh(TowerDefenseHeadStateData headStateData, Vector rootWorldPos)
		{
			headStateData.Position.Subtraction(rootWorldPos, this.TmpVector);
			FVector2D fvector2D = new FVector2D((float)this.TmpVector.X, (float)this.TmpVector.Y);
			foreach (UUITextAdditionalUVModifier uuitextAdditionalUVModifier in this.UvModifierList)
			{
				uuitextAdditionalUVModifier.SetAdditionalUV(0, fvector2D);
			}
			fvector2D = new FVector2D((float)this.TmpVector.Z, (float)headStateData.ActorScale.X);
			foreach (UUITextAdditionalUVModifier uuitextAdditionalUVModifier2 in this.UvModifierList)
			{
				uuitextAdditionalUVModifier2.SetAdditionalUV(1, fvector2D);
			}
			FVector2D fvector2D2;
			foreach (UUITextAdditionalUVModifier uuitextAdditionalUVModifier3 in this.UvModifierList)
			{
				AUIBaseActor auibaseActor = uuitextAdditionalUVModifier3.GetOwner() as AUIBaseActor;
				UUIItem uuiitem = (auibaseActor != null) ? auibaseActor.GetUIItem() : null;
				float inX = (uuiitem != null) ? uuiitem.GetPivot().X : 0f;
				float inY = (uuiitem != null) ? uuiitem.GetWidth() : 1f;
				int additionalUVChannel = 2;
				fvector2D2 = new FVector2D(inX, inY);
				uuitextAdditionalUVModifier3.SetAdditionalUV(additionalUVChannel, fvector2D2);
				int additionalUVChannel2 = -1;
				fvector2D2 = new FVector2D(1f, 0f);
				uuitextAdditionalUVModifier3.SetAdditionalUV(additionalUVChannel2, fvector2D2);
			}
			UUITextAdditionalUVModifier uuitextAdditionalUVModifier4 = this.HpBarSprite.GetOwner().GetComponentByClass(UUITextAdditionalUVModifier.StaticClass()) as UUITextAdditionalUVModifier;
			UUITextAdditionalUVModifier uuitextAdditionalUVModifier5 = this.HpBarBufferSprite.GetOwner().GetComponentByClass(UUITextAdditionalUVModifier.StaticClass()) as UUITextAdditionalUVModifier;
			UUITextAdditionalUVModifier uuitextAdditionalUVModifier6 = this.ShieldBarSprite.GetOwner().GetComponentByClass(UUITextAdditionalUVModifier.StaticClass()) as UUITextAdditionalUVModifier;
			UUITextAdditionalUVModifier uuitextAdditionalUVModifier7 = uuitextAdditionalUVModifier4;
			int additionalUVChannel3 = -1;
			fvector2D2 = new FVector2D(headStateData.HpPercent, 0f);
			uuitextAdditionalUVModifier7.SetAdditionalUV(additionalUVChannel3, fvector2D2);
			UUITextAdditionalUVModifier uuitextAdditionalUVModifier8 = uuitextAdditionalUVModifier5;
			int additionalUVChannel4 = -1;
			fvector2D2 = new FVector2D(headStateData.HpBufferPercent, 0f);
			uuitextAdditionalUVModifier8.SetAdditionalUV(additionalUVChannel4, fvector2D2);
			int additionalUVChannel5 = -1;
			fvector2D2 = new FVector2D(headStateData.ShieldPercent, 0f);
			uuitextAdditionalUVModifier6.SetAdditionalUV(additionalUVChannel5, fvector2D2);
		}

		// Token: 0x0401E06B RID: 122987
		[Nullable(2)]
		private UUISprite HpBarSprite;

		// Token: 0x0401E06C RID: 122988
		[Nullable(2)]
		private UUISprite HpBarBufferSprite;

		// Token: 0x0401E06D RID: 122989
		[Nullable(2)]
		private UUISprite ShieldBarSprite;

		// Token: 0x0401E06E RID: 122990
		private readonly List<UUITextAdditionalUVModifier> UvModifierList = new List<UUITextAdditionalUVModifier>();

		// Token: 0x0401E06F RID: 122991
		private readonly Vector TmpVector = Vector.Create();

		// Token: 0x0200AE30 RID: 44592
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x04036177 RID: 221559
			HpBarSprite,
			// Token: 0x04036178 RID: 221560
			HpBarBufferSprite,
			// Token: 0x04036179 RID: 221561
			ShieldBarSprite
		}
	}
}
