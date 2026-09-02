using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.SimpleCombat._3_3Pinball.GameBase.SpawnObj;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC0 RID: 28608
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballBattleFeverBarController
	{
		// Token: 0x0604529F RID: 283295 RVA: 0x0120D208 File Offset: 0x0120B408
		[NullableContext(1)]
		public void Init(BP_Fever_Bar_C feverBar, float dissolveMin, float dissolveMax, [Nullable(2)] UMaterialInstance material)
		{
			this.MaterialParamName = new FName("Dissolve_Dissolve");
			TArray<UActorComponent> tarray = feverBar.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
			if (tarray != null)
			{
				for (int i = 0; i < tarray.Num(); i++)
				{
					UStaticMeshComponent ustaticMeshComponent = (UStaticMeshComponent)tarray.Get(i);
					string name = ustaticMeshComponent.GetName();
					if (name == "Mesh")
					{
						UMaterialInstanceDynamic umaterialInstanceDynamic = ustaticMeshComponent.CreateDynamicMaterialInstance(0, ustaticMeshComponent.GetMaterial(0), default(FName));
						if (umaterialInstanceDynamic != null)
						{
							umaterialInstanceDynamic.SetScalarParameterValue(this.MaterialParamName, 0f);
							this.FeverBarMaterial = umaterialInstanceDynamic;
						}
					}
					else if (name == "Bg")
					{
						if (material != null)
						{
							ustaticMeshComponent.SetMaterial(0, material);
						}
						ustaticMeshComponent.SetScalarParameterValueOnMaterials(this.MaterialParamName, 1f);
					}
				}
			}
			this.DissolveMin = dissolveMin;
			this.DissolveMax = dissolveMax;
			this.DissolveRange = this.DissolveMax - this.DissolveMin;
		}

		// Token: 0x060452A0 RID: 283296 RVA: 0x0120D2FC File Offset: 0x0120B4FC
		[NullableContext(1)]
		public void BindAttr(AKSC_Shape2D_Entity_TeamPlayer kscTeamPlayer)
		{
			UKSC_SkillComp skillComp = kscTeamPlayer.GetSkillComp();
			UKSC_AttrSet uksc_AttrSet = (skillComp != null) ? skillComp.AttrSet_ : null;
			if (uksc_AttrSet != null)
			{
				this.AttrSet = uksc_AttrSet;
				TMap<EKSC_AttrType, int> attrs_ = uksc_AttrSet.Attrs_;
				this.FeverValue = (float)((attrs_ != null) ? attrs_.GetValueOrNull(EKSC_AttrType.SpecialEnergy3) : null).GetValueOrDefault();
				TMap<EKSC_AttrType, int> attrs_2 = uksc_AttrSet.Attrs_;
				this.FeverMaxValue = (float)((attrs_2 != null) ? attrs_2.GetValueOrNull(EKSC_AttrType.SpecialEnergy3Max) : null).GetValueOrDefault();
				this.DelegateFeverAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnFeverAttrChange));
				this.DelegateFeverMaxAttrChange = global::DelegateUtils.ToManualReleaseDelegate<FOnKSCAttrChange>(new Action<EKSC_AttrType, int>(this.OnFeverMaxAttrChange));
				uksc_AttrSet.AssignAttrListen(EKSC_AttrType.SpecialEnergy3, this.DelegateFeverAttrChange);
				uksc_AttrSet.AssignAttrListen(EKSC_AttrType.SpecialEnergy3Max, this.DelegateFeverMaxAttrChange);
				this.UpdateFeverBar();
			}
		}

		// Token: 0x060452A1 RID: 283297 RVA: 0x0120D3D0 File Offset: 0x0120B5D0
		public void Destroy()
		{
			this.MaterialParamName = default(FName);
			if (this.AttrSet != null)
			{
				if (this.DelegateFeverAttrChange != null)
				{
					this.AttrSet.RemoveAttrListen(EKSC_AttrType.SpecialEnergy3, this.DelegateFeverAttrChange);
				}
				if (this.DelegateFeverMaxAttrChange != null)
				{
					this.AttrSet.RemoveAttrListen(EKSC_AttrType.SpecialEnergy3Max, this.DelegateFeverMaxAttrChange);
				}
				this.AttrSet = null;
			}
			if (this.DelegateFeverAttrChange != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnFeverAttrChange));
				this.DelegateFeverAttrChange = null;
			}
			if (this.DelegateFeverMaxAttrChange != null)
			{
				global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<EKSC_AttrType, int>(this.OnFeverMaxAttrChange));
				this.DelegateFeverMaxAttrChange = null;
			}
		}

		// Token: 0x060452A2 RID: 283298 RVA: 0x0120D470 File Offset: 0x0120B670
		private void UpdateFeverBar()
		{
			float num = (this.FeverMaxValue > 0f) ? (this.FeverValue / this.FeverMaxValue) : 0f;
			float value = this.DissolveMin + num * this.DissolveRange;
			UMaterialInstanceDynamic feverBarMaterial = this.FeverBarMaterial;
			if (feverBarMaterial == null)
			{
				return;
			}
			feverBarMaterial.SetScalarParameterValue(this.MaterialParamName, value);
		}

		// Token: 0x060452A3 RID: 283299 RVA: 0x0120D4C6 File Offset: 0x0120B6C6
		private void OnFeverAttrChange(EKSC_AttrType attrType, int value)
		{
			this.FeverValue = (float)value;
			this.RefreshFever();
			this.UpdateFeverBar();
		}

		// Token: 0x060452A4 RID: 283300 RVA: 0x0120D4DC File Offset: 0x0120B6DC
		private void OnFeverMaxAttrChange(EKSC_AttrType attrType, int value)
		{
			this.FeverMaxValue = (float)value;
			this.RefreshFever();
			this.UpdateFeverBar();
		}

		// Token: 0x060452A5 RID: 283301 RVA: 0x0120D4F4 File Offset: 0x0120B6F4
		private void RefreshFever()
		{
			bool flag = this.FeverValue <= 0f;
			bool flag2 = this.FeverValue >= this.FeverMaxValue;
			if (!flag && !flag2)
			{
				this.IsInProgress = true;
				return;
			}
			if (!this.IsInProgress)
			{
				return;
			}
			this.IsInProgress = false;
			if (flag2)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPinballFeverChange, true);
				return;
			}
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnPinballFeverChange, false);
			}
		}

		// Token: 0x04026963 RID: 158051
		private UKSC_AttrSet AttrSet;

		// Token: 0x04026964 RID: 158052
		private UMaterialInstanceDynamic FeverBarMaterial;

		// Token: 0x04026965 RID: 158053
		private FName MaterialParamName;

		// Token: 0x04026966 RID: 158054
		private float FeverValue;

		// Token: 0x04026967 RID: 158055
		private float FeverMaxValue;

		// Token: 0x04026968 RID: 158056
		private float DissolveMin;

		// Token: 0x04026969 RID: 158057
		private float DissolveMax = 1f;

		// Token: 0x0402696A RID: 158058
		private float DissolveRange = 1f;

		// Token: 0x0402696B RID: 158059
		private FOnKSCAttrChange DelegateFeverAttrChange;

		// Token: 0x0402696C RID: 158060
		private FOnKSCAttrChange DelegateFeverMaxAttrChange;

		// Token: 0x0402696D RID: 158061
		private bool IsInProgress;

		// Token: 0x0402696E RID: 158062
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat UpdateStat = Stat.Create("PinballBattlePlayerBarController.UpdateFeverBar", "", "");
	}
}
