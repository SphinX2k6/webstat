using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.ExtraEffect
{
	// Token: 0x0200498C RID: 18828
	[NullableContext(1)]
	[Nullable(0)]
	public class ConvertAbnormalLight : PeriodExecution
	{
		// Token: 0x06031308 RID: 201480 RVA: 0x00C3F2A3 File Offset: 0x00C3D4A3
		public ConvertAbnormalLight(RequireAndLimits requireAndLimits) : base(requireAndLimits)
		{
		}

		// Token: 0x06031309 RID: 201481 RVA: 0x00C3F2B8 File Offset: 0x00C3D4B8
		protected override void InitParameters(ExtraEffectParameters parameters)
		{
			this._targetBuffIds = new List<ValueTuple<int, long>>();
			string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
			if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0 && !string.IsNullOrEmpty(extraEffectParameters_[0]))
			{
				string[] array = extraEffectParameters_[0].Split('|', StringSplitOptions.None);
				for (int i = 0; i < array.Length; i++)
				{
					string[] array2 = array[i].Split('#', StringSplitOptions.None);
					if (array2.Length >= 2)
					{
						this._targetBuffIds.Add(new ValueTuple<int, long>(int.Parse(array2[0]), long.Parse(array2[1])));
					}
				}
			}
			string s = (extraEffectParameters_ != null && extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1])) ? extraEffectParameters_[1] : 1005.ToString();
			this._extractEffectId = int.Parse(s);
			string s2 = (extraEffectParameters_ != null && extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2])) ? extraEffectParameters_[2] : "0";
			this._maxStackCount = int.Parse(s2);
			string s3 = (extraEffectParameters_ != null && extraEffectParameters_.Length > 3 && !string.IsNullOrEmpty(extraEffectParameters_[3])) ? extraEffectParameters_[3] : "0";
			this.TargetType = (EExecutionTargetType)int.Parse(s3);
		}

		// Token: 0x0603130A RID: 201482 RVA: 0x00C3F3C8 File Offset: 0x00C3D5C8
		[return: Nullable(2)]
		public override object OnExecute(params object[] args)
		{
			IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
			if (ownerBuffComponent == null)
			{
				return null;
			}
			int num = 0;
			HashSet<int> buffHandleByEffectId = ownerBuffComponent.GetBuffHandleByEffectId(this._extractEffectId);
			if (buffHandleByEffectId == null)
			{
				return null;
			}
			foreach (int num2 in buffHandleByEffectId)
			{
				IActiveBuff buffByHandle = ownerBuffComponent.GetBuffByHandle(num2);
				if (buffByHandle != null)
				{
					num += buffByHandle.StackCount;
					if (num > this._maxStackCount && this._maxStackCount != 0)
					{
						ownerBuffComponent.RemoveBuffByHandle(num2, buffByHandle.StackCount - (num - this._maxStackCount), "buff额外效果1102", null, null, null);
						num = this._maxStackCount;
						break;
					}
					ownerBuffComponent.RemoveBuffByHandle(num2, -1, "buff额外效果1102", null, null, null);
				}
			}
			long num3 = 0L;
			for (int i = this._targetBuffIds.Count - 1; i >= 0; i--)
			{
				ValueTuple<int, long> valueTuple = this._targetBuffIds[i];
				int item = valueTuple.Item1;
				long item2 = valueTuple.Item2;
				if (num >= item)
				{
					num3 = item2;
					break;
				}
			}
			if (num3 <= 0L)
			{
				return null;
			}
			IBuffComponent effectTarget = base.GetEffectTarget();
			if (effectTarget != null)
			{
				effectTarget.AddIterativeBuff(num3, this.Buff, null, true, "buff额外效果1102", null, null);
			}
			return null;
		}

		// Token: 0x0401C4E7 RID: 115943
		private const int DefaultRemoveEffectId = 1005;

		// Token: 0x0401C4E8 RID: 115944
		private const string Reason = "buff额外效果1102";

		// Token: 0x0401C4E9 RID: 115945
		[TupleElementNames(new string[]
		{
			"lowerBound",
			"buffId"
		})]
		[Nullable(new byte[]
		{
			1,
			0
		})]
		private List<ValueTuple<int, long>> _targetBuffIds = new List<ValueTuple<int, long>>();

		// Token: 0x0401C4EA RID: 115946
		private int _extractEffectId;

		// Token: 0x0401C4EB RID: 115947
		private int _maxStackCount;
	}
}
