using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052EF RID: 21231
	public class QuickHackFormationAttributeRamManager : QuickHackRamManager
	{
		// Token: 0x0603634C RID: 222028 RVA: 0x00DA8E4C File Offset: 0x00DA704C
		[NullableContext(2)]
		public override void Init(int param, Action<float> onCurrentRamChange = null, Action<float> onMaxRamChange = null)
		{
			base.Init(param, onCurrentRamChange, onMaxRamChange);
			this.AttributeId = (EFormationAttributeId)param;
			if (onCurrentRamChange != null)
			{
				ControllerBase<FormationAttributeController>.Instance.AddValueListener(this.AttributeId, new TValueListener(this.OnAttributeValueChange), null);
			}
			if (onMaxRamChange != null)
			{
				ControllerBase<FormationAttributeController>.Instance.AddMaxListener(this.AttributeId, new TValueListener(this.OnAttributeMaxChange), null);
			}
		}

		// Token: 0x0603634D RID: 222029 RVA: 0x00DA8EA9 File Offset: 0x00DA70A9
		private void OnAttributeValueChange(EFormationAttributeId attrId, float newValue, float oldValue)
		{
			Action<float> onCurrentRamChange = this.OnCurrentRamChange;
			if (onCurrentRamChange == null)
			{
				return;
			}
			onCurrentRamChange(newValue);
		}

		// Token: 0x0603634E RID: 222030 RVA: 0x00DA8EBC File Offset: 0x00DA70BC
		private void OnAttributeMaxChange(EFormationAttributeId attrId, float newValue, float oldValue)
		{
			Action<float> onMaxRamChange = this.OnMaxRamChange;
			if (onMaxRamChange == null)
			{
				return;
			}
			onMaxRamChange(newValue);
		}

		// Token: 0x0603634F RID: 222031 RVA: 0x00DA8ED0 File Offset: 0x00DA70D0
		public override void Clear()
		{
			if (this.OnCurrentRamChange != null)
			{
				ControllerBase<FormationAttributeController>.Instance.RemoveValueListener(this.AttributeId, new TValueListener(this.OnAttributeValueChange));
			}
			if (this.OnMaxRamChange != null)
			{
				ControllerBase<FormationAttributeController>.Instance.RemoveMaxListener(this.AttributeId, new TValueListener(this.OnAttributeMaxChange));
			}
			this.AttributeId = (EFormationAttributeId)0;
			base.Clear();
		}

		// Token: 0x06036350 RID: 222032 RVA: 0x00DA8F32 File Offset: 0x00DA7132
		public override float GetCurrentRam()
		{
			return ControllerBase<FormationAttributeController>.Instance.GetValue(this.AttributeId);
		}

		// Token: 0x06036351 RID: 222033 RVA: 0x00DA8F44 File Offset: 0x00DA7144
		public override float GetMaxRam()
		{
			return ControllerBase<FormationAttributeController>.Instance.GetMax(this.AttributeId);
		}

		// Token: 0x06036352 RID: 222034 RVA: 0x00DA8F56 File Offset: 0x00DA7156
		public override void ChangeRam(float addValue)
		{
			ControllerBase<FormationAttributeController>.Instance.AddValue(this.AttributeId, addValue);
		}

		// Token: 0x0401F2B6 RID: 127670
		private EFormationAttributeId AttributeId;
	}
}
