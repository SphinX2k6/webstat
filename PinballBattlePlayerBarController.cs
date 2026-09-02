using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.KuroSimpleCombat.PB;
using UnrealEngine;

// Token: 0x02000F67 RID: 3943
[NullableContext(1)]
[Nullable(0)]
public class PinballBattlePlayerBarController
{
	// Token: 0x060063A2 RID: 25506 RVA: 0x0018F7E4 File Offset: 0x0018D9E4
	public void Init(AKSC_Shape2D_Entity_Bar playerBar, PinballBattleSubModel model)
	{
		this.Model = model;
		this.MaterialMap = new Dictionary<int, UMaterialInstanceDynamic>();
		this.MaterialParamName = new FName("Dissolve_Dissolve");
		FName parameterName = new FName("Dissolve_Smooth");
		TArray<UActorComponent> tarray = playerBar.K2_GetComponentsByClass(UStaticMeshComponent.StaticClass());
		if (tarray != null)
		{
			for (int i = 0; i < tarray.Num(); i++)
			{
				UStaticMeshComponent ustaticMeshComponent = (UStaticMeshComponent)tarray.Get(i);
				string name = ustaticMeshComponent.GetName();
				if (name == "Level1" || name == "Level2" || name == "Level3")
				{
					int key = int.Parse(name[5].ToString());
					UMaterialInstanceDynamic umaterialInstanceDynamic = ustaticMeshComponent.CreateDynamicMaterialInstance(0, ustaticMeshComponent.GetMaterial(0), default(FName));
					if (umaterialInstanceDynamic != null)
					{
						umaterialInstanceDynamic.SetScalarParameterValue(this.MaterialParamName, 0f);
						umaterialInstanceDynamic.SetScalarParameterValue(parameterName, 100000f);
						this.MaterialMap[key] = umaterialInstanceDynamic;
					}
				}
				else if (name == "Bg")
				{
					ustaticMeshComponent.SetScalarParameterValueOnMaterials(this.MaterialParamName, 1f);
				}
			}
		}
		TArray<UActorComponent> tarray2 = playerBar.K2_GetComponentsByClass(UNiagaraComponent.StaticClass());
		if (tarray2 != null)
		{
			for (int j = 0; j < tarray2.Num(); j++)
			{
				UNiagaraComponent uniagaraComponent = (UNiagaraComponent)tarray2.Get(j);
				if (uniagaraComponent.GetName() == "FullCombo")
				{
					this.FullComboEffect = uniagaraComponent;
					break;
				}
			}
		}
		UKSC_DA_Shape2D_World shapeWorldDa = model.ShapeWorldDa;
		if (shapeWorldDa != null)
		{
			float comboEfficiency = model.ComboEfficiency;
			this.LevelComboCounts = new int[]
			{
				0,
				(int)Math.Ceiling((double)((float)shapeWorldDa.PowerCollisionCount1 * Math.Max(1f - comboEfficiency, 0f))),
				(int)Math.Ceiling((double)((float)shapeWorldDa.PowerCollisionCount2 * Math.Max(1f - comboEfficiency, 0f))),
				(int)Math.Ceiling((double)((float)shapeWorldDa.PowerCollisionCount3 * Math.Max(1f - comboEfficiency, 0f)))
			};
			this.MaxCombo = this.LevelComboCounts[3];
		}
		this.ResetPlayerBar();
	}

	// Token: 0x060063A3 RID: 25507 RVA: 0x0018FA11 File Offset: 0x0018DC11
	public void Destroy()
	{
		this.Model = null;
		Dictionary<int, UMaterialInstanceDynamic> materialMap = this.MaterialMap;
		if (materialMap != null)
		{
			materialMap.Clear();
		}
		this.MaterialParamName = default(FName);
		this.FullComboEffect = null;
	}

	// Token: 0x060063A4 RID: 25508 RVA: 0x0018FA40 File Offset: 0x0018DC40
	public void Update()
	{
		if (this.Model == null)
		{
			return;
		}
		int combo = this.Model.Combo;
		if (combo != this.Combo)
		{
			this.Combo = combo;
			if (combo != 0)
			{
				this.UpdatePlayerBar();
			}
			else
			{
				this.ComboLevel = 0;
				this.ResetPlayerBar();
			}
		}
		if (this.MaxCombo > 0)
		{
			this.ShowFullComboEffect(combo >= this.MaxCombo);
		}
	}

	// Token: 0x060063A5 RID: 25509 RVA: 0x0018FAA8 File Offset: 0x0018DCA8
	private void UpdatePlayerBar()
	{
		for (int i = 1; i < this.LevelComboCounts.Length; i++)
		{
			int num = this.LevelComboCounts[i];
			int num2 = this.LevelComboCounts[i - 1];
			if (this.Combo >= num)
			{
				if (this.ComboLevel < i)
				{
					this.ComboLevel = i;
					UMaterialInstanceDynamic umaterialInstanceDynamic;
					if (this.MaterialMap != null && this.MaterialMap.TryGetValue(i, out umaterialInstanceDynamic))
					{
						umaterialInstanceDynamic.SetScalarParameterValue(this.MaterialParamName, 1f);
					}
				}
			}
			else if (this.ComboLevel == i - 1)
			{
				float value = Math.Min((float)(this.Combo - num2) / (float)(num - num2), 1f);
				UMaterialInstanceDynamic umaterialInstanceDynamic2;
				if (this.MaterialMap != null && this.MaterialMap.TryGetValue(i, out umaterialInstanceDynamic2))
				{
					umaterialInstanceDynamic2.SetScalarParameterValue(this.MaterialParamName, value);
				}
			}
		}
	}

	// Token: 0x060063A6 RID: 25510 RVA: 0x0018FB74 File Offset: 0x0018DD74
	private void ResetPlayerBar()
	{
		if (this.MaterialMap != null)
		{
			foreach (UMaterialInstanceDynamic umaterialInstanceDynamic in this.MaterialMap.Values)
			{
				umaterialInstanceDynamic.SetScalarParameterValue(this.MaterialParamName, 0f);
			}
		}
	}

	// Token: 0x060063A7 RID: 25511 RVA: 0x0018FBDC File Offset: 0x0018DDDC
	private void ShowFullComboEffect(bool isShow)
	{
		if (isShow == this.IsShowFullComboEffect)
		{
			return;
		}
		this.IsShowFullComboEffect = isShow;
		UNiagaraComponent fullComboEffect = this.FullComboEffect;
		if (fullComboEffect == null)
		{
			return;
		}
		fullComboEffect.SetHiddenInGame(!isShow, false);
	}

	// Token: 0x04002FA4 RID: 12196
	private FName MaterialParamName;

	// Token: 0x04002FA5 RID: 12197
	private int Combo;

	// Token: 0x04002FA6 RID: 12198
	private int ComboLevel;

	// Token: 0x04002FA7 RID: 12199
	private int[] LevelComboCounts = Array.Empty<int>();

	// Token: 0x04002FA8 RID: 12200
	private int MaxCombo;

	// Token: 0x04002FA9 RID: 12201
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, UMaterialInstanceDynamic> MaterialMap;

	// Token: 0x04002FAA RID: 12202
	[Nullable(2)]
	private UNiagaraComponent FullComboEffect;

	// Token: 0x04002FAB RID: 12203
	private bool IsShowFullComboEffect;

	// Token: 0x04002FAC RID: 12204
	[Nullable(2)]
	private PinballBattleSubModel Model;

	// Token: 0x04002FAD RID: 12205
	[StaticVariableRuleIgnore]
	private static readonly Stat UpdateStat = Stat.Create("PinballBattlePlayerBarController.UpdatePlayerBar", "", "");
}
