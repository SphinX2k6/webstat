using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x02004987 RID: 18823
	[NullableContext(1)]
	[Nullable(0)]
	public class AbnormalIce : BuffEffect
	{
		// Token: 0x060312F5 RID: 201461 RVA: 0x00C3F0E5 File Offset: 0x00C3D2E5
		public AbnormalIce(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
		{
		}

		// Token: 0x060312F6 RID: 201462 RVA: 0x00C3F100 File Offset: 0x00C3D300
		protected override void InitParameters(ExtraEffectParameters parameters)
		{
			this._modifierValue.Clear();
			if (parameters.ExtraEffectParameters_ == null)
			{
				return;
			}
			string[] array = (parameters.ExtraEffectParameters_.ElementAtOrDefault(0) ?? "").Split('|', StringSplitOptions.None);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Trim().Split('#', StringSplitOptions.None);
				this._modifierValue.Add(new ValueTuple<int, int>(int.Parse(array2[0].Trim()), int.Parse(array2[1].Trim())));
			}
		}

		// Token: 0x060312F7 RID: 201463 RVA: 0x00C3F188 File Offset: 0x00C3D388
		public override void OnCreated()
		{
		}

		// Token: 0x060312F8 RID: 201464 RVA: 0x00C3F18A File Offset: 0x00C3D38A
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			return null;
		}

		// Token: 0x060312F9 RID: 201465 RVA: 0x00C3F18D File Offset: 0x00C3D38D
		public override void OnRemoved(bool bPremature)
		{
		}

		// Token: 0x060312FA RID: 201466 RVA: 0x00C3F18F File Offset: 0x00C3D38F
		public override void OnStackIncreased(int newCount, int oldCount, long? instigatorId)
		{
		}

		// Token: 0x060312FB RID: 201467 RVA: 0x00C3F191 File Offset: 0x00C3D391
		public override void OnStackDecreased(int newCount, int oldCount, bool bPremature)
		{
		}

		// Token: 0x060312FC RID: 201468 RVA: 0x00C3F194 File Offset: 0x00C3D394
		public void ClearModifier()
		{
			Entity exactOwnerEntity = base.ExactOwnerEntity;
			BaseAttributeComponent baseAttributeComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<BaseAttributeComponent>() : null;
			if (this._modifierHandle != 0)
			{
				if (baseAttributeComponent != null)
				{
					baseAttributeComponent.RemoveModifier(EAttributeType.SpeedRatio, this._modifierHandle);
				}
				this._modifierHandle = 0;
			}
		}

		// Token: 0x060312FD RID: 201469 RVA: 0x00C3F1D4 File Offset: 0x00C3D3D4
		public void RefreshModifier(int stackCount)
		{
			this.ClearModifier();
			Entity exactOwnerEntity = base.ExactOwnerEntity;
			BaseAttributeComponent baseAttributeComponent = (exactOwnerEntity != null) ? exactOwnerEntity.GetComponent<BaseAttributeComponent>() : null;
			if (baseAttributeComponent == null)
			{
				return;
			}
			int num = 0;
			for (int i = this._modifierValue.Count - 1; i >= 0; i--)
			{
				ValueTuple<int, int> valueTuple = this._modifierValue[i];
				int item = valueTuple.Item1;
				int item2 = valueTuple.Item2;
				if (stackCount >= item)
				{
					num = item2;
					break;
				}
			}
			this._modifierHandle = baseAttributeComponent.AddModifier(EAttributeType.SpeedRatio, new CharacterAttributeTypes.AttributeModifier
			{
				Type = ECalculationPolicyType.AddFromAttr,
				Value1 = (float)(num - 10000)
			});
		}

		// Token: 0x0401C4E5 RID: 115941
		private int _modifierHandle;

		// Token: 0x0401C4E6 RID: 115942
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private readonly List<ValueTuple<int, int>> _modifierValue = new List<ValueTuple<int, int>>();
	}
}
