using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Core.Fight;
using CSharpScript.Game.Module;

// Token: 0x0200294E RID: 10574
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class SceneBattleInteractModel : ModelBase<SceneBattleInteractModel>
{
	// Token: 0x0601501D RID: 86045 RVA: 0x005CF714 File Offset: 0x005CD914
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0601501E RID: 86046 RVA: 0x005CF717 File Offset: 0x005CD917
	protected override bool OnClear()
	{
		this.ClearAllEffect();
		this.ClearAllConfig();
		SceneBattleInteractPool.Clear();
		return true;
	}

	// Token: 0x0601501F RID: 86047 RVA: 0x005CF72B File Offset: 0x005CD92B
	protected override bool OnLeaveLevel()
	{
		this.ClearAllEffect();
		this.ClearAllConfig();
		SceneBattleInteractPool.Clear();
		return true;
	}

	// Token: 0x06015020 RID: 86048 RVA: 0x005CF740 File Offset: 0x005CD940
	[NullableContext(1)]
	[return: Nullable(2)]
	public SceneBattleInteractEffect CreateSceneBattleInteract(BP_SceneBattleInteract_C dataAsset, float radius = 0f, float halfHeight = 0f)
	{
		if (!this.Open)
		{
			return null;
		}
		SceneBattleInteractEffect sceneBattleInteractEffect = new SceneBattleInteractEffect();
		this.GenId++;
		sceneBattleInteractEffect.Id = this.GenId;
		sceneBattleInteractEffect.Init(dataAsset, radius, halfHeight);
		this.EffectMap[sceneBattleInteractEffect.Id] = sceneBattleInteractEffect;
		return sceneBattleInteractEffect;
	}

	// Token: 0x06015021 RID: 86049 RVA: 0x005CF794 File Offset: 0x005CD994
	public void DestroySceneBattleInteract(int handleId)
	{
		SceneBattleInteractEffect sceneBattleInteractEffect;
		if (!this.EffectMap.TryGetValue(handleId, out sceneBattleInteractEffect))
		{
			return;
		}
		sceneBattleInteractEffect.Destroy();
		this.EffectMap.Remove(handleId);
	}

	// Token: 0x06015022 RID: 86050 RVA: 0x005CF7C8 File Offset: 0x005CD9C8
	public bool SetSceneBattleInteractEnable(int handleId, bool enable, float limitTime = 0f)
	{
		SceneBattleInteractEffect sceneBattleInteractEffect;
		if (!this.EffectMap.TryGetValue(handleId, out sceneBattleInteractEffect))
		{
			return false;
		}
		sceneBattleInteractEffect.SetEnable(enable, limitTime);
		return true;
	}

	// Token: 0x06015023 RID: 86051 RVA: 0x005CF7F0 File Offset: 0x005CD9F0
	public SceneBattleInteractEffect GetSceneBattleInteract(int handleId)
	{
		SceneBattleInteractEffect result;
		if (this.EffectMap.TryGetValue(handleId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x06015024 RID: 86052 RVA: 0x005CF810 File Offset: 0x005CDA10
	public BP_SceneBattleInteract_C GetDefaultWeaponInteractConfig()
	{
		if (!this.Open)
		{
			return null;
		}
		if (this.DefaultWeaponInteractConfig == null)
		{
			this.DefaultWeaponInteractConfig = Singleton<ResourceSystem>.Instance.Load<BP_SceneBattleInteract_C>("/Game/Aki/Data/Fight/DA_WeaponSceneInteract.DA_WeaponSceneInteract", "js_undefined");
		}
		return this.DefaultWeaponInteractConfig;
	}

	// Token: 0x06015025 RID: 86053 RVA: 0x005CF844 File Offset: 0x005CDA44
	public BP_SceneBattleInteract_C GetWeaponInteractConfig(int weaponType)
	{
		if (!this.Open)
		{
			return null;
		}
		if (weaponType <= 0)
		{
			return null;
		}
		BP_SceneBattleInteract_C bp_SceneBattleInteract_C;
		if (this.WeaponInteractConfigMap.TryGetValue(weaponType, out bp_SceneBattleInteract_C) && bp_SceneBattleInteract_C != null)
		{
			return bp_SceneBattleInteract_C;
		}
		WeaponSceneInteract? weaponSceneInteract;
		string text = (ConfigWeaponSceneInteractById.GetConfig(weaponType, true) != null) ? weaponSceneInteract.GetValueOrDefault().Path : null;
		if (text == null)
		{
			return null;
		}
		BP_SceneBattleInteract_C bp_SceneBattleInteract_C2 = Singleton<ResourceSystem>.Instance.Load<BP_SceneBattleInteract_C>(text, "js_undefined");
		this.WeaponInteractConfigMap[weaponType] = bp_SceneBattleInteract_C2;
		return bp_SceneBattleInteract_C2;
	}

	// Token: 0x17001B8D RID: 7053
	// (get) Token: 0x06015026 RID: 86054 RVA: 0x005CF8BF File Offset: 0x005CDABF
	// (set) Token: 0x06015027 RID: 86055 RVA: 0x005CF8C7 File Offset: 0x005CDAC7
	public bool Open
	{
		get
		{
			return this.OpenInternal;
		}
		set
		{
			if (this.OpenInternal == value)
			{
				return;
			}
			this.OpenInternal = value;
			if (!this.OpenInternal)
			{
				this.ClearAllEffect();
			}
		}
	}

	// Token: 0x17001B8E RID: 7054
	// (get) Token: 0x06015028 RID: 86056 RVA: 0x005CF8E8 File Offset: 0x005CDAE8
	// (set) Token: 0x06015029 RID: 86057 RVA: 0x005CF8F0 File Offset: 0x005CDAF0
	public int Debug
	{
		get
		{
			return this.DebugInternal;
		}
		set
		{
			if (this.DebugInternal == value)
			{
				return;
			}
			this.DebugInternal = value;
			foreach (SceneBattleInteractEffect sceneBattleInteractEffect in this.EffectMap.Values)
			{
				sceneBattleInteractEffect.SetDebug(this.DebugInternal);
			}
		}
	}

	// Token: 0x0601502A RID: 86058 RVA: 0x005CF95C File Offset: 0x005CDB5C
	private void ClearAllEffect()
	{
		foreach (SceneBattleInteractEffect sceneBattleInteractEffect in this.EffectMap.Values)
		{
			sceneBattleInteractEffect.Destroy();
		}
		this.EffectMap.Clear();
	}

	// Token: 0x0601502B RID: 86059 RVA: 0x005CF9BC File Offset: 0x005CDBBC
	private void ClearAllConfig()
	{
		this.DefaultWeaponInteractConfig = null;
		this.WeaponInteractConfigMap.Clear();
	}

	// Token: 0x0601502C RID: 86060 RVA: 0x005CF9D0 File Offset: 0x005CDBD0
	public void RefreshIgnoreCommonWeapon(bool needIgnore)
	{
		if (needIgnore)
		{
			this.IgnoreCommonWeapon = true;
			return;
		}
		using (Dictionary<int, SceneBattleInteractEffect>.ValueCollection.Enumerator enumerator = this.EffectMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetIgnoreCommonWeapon())
				{
					this.IgnoreCommonWeapon = true;
					return;
				}
			}
		}
		this.IgnoreCommonWeapon = false;
	}

	// Token: 0x0400A1C9 RID: 41417
	private int GenId;

	// Token: 0x0400A1CA RID: 41418
	private bool OpenInternal;

	// Token: 0x0400A1CB RID: 41419
	private int DebugInternal;

	// Token: 0x0400A1CC RID: 41420
	[Nullable(1)]
	public readonly Dictionary<int, SceneBattleInteractEffect> EffectMap = new Dictionary<int, SceneBattleInteractEffect>();

	// Token: 0x0400A1CD RID: 41421
	public BP_SceneBattleInteract_C DefaultWeaponInteractConfig;

	// Token: 0x0400A1CE RID: 41422
	[Nullable(new byte[]
	{
		1,
		2
	})]
	public readonly Dictionary<int, BP_SceneBattleInteract_C> WeaponInteractConfigMap = new Dictionary<int, BP_SceneBattleInteract_C>();

	// Token: 0x0400A1CF RID: 41423
	public bool IgnoreCommonWeapon;
}
