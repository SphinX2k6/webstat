using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003145 RID: 12613
[NullableContext(2)]
[Nullable(0)]
public class SpecialSkillBuling : SpecialSkillBase
{
	// Token: 0x0601A1D0 RID: 106960 RVA: 0x007A9565 File Offset: 0x007A7765
	[NullableContext(1)]
	public SpecialSkillBuling(CharacterSpecialSkillComponent specialSkillComponent) : base(specialSkillComponent)
	{
	}

	// Token: 0x0601A1D1 RID: 106961 RVA: 0x007A9584 File Offset: 0x007A7784
	public override void OnStart()
	{
		this.EntityRef = this.SpecialSkillComponent.Entity;
		this.AttributeComponent = this.EntityRef.GetComponent<BaseAttributeComponent>();
		this.TagComponent = this.EntityRef.GetComponent<RoleTagComponent>();
		this.ActorComponent = this.EntityRef.CheckGetComponent<CharacterActorComponent>();
		this.InitSpecialEnergy();
		CharacterActorComponent actorComponent = this.ActorComponent;
		if (actorComponent != null && actorComponent.IsRoleAndCtrlByMe)
		{
			if (this.AttributeComponent != null)
			{
				this.AttributeComponent.AddListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged), null);
				this.IsAddAttributeListener = true;
			}
			this.InitSlotEnergyTags();
			this.SetSpecialEnergyTag();
		}
	}

	// Token: 0x0601A1D2 RID: 106962 RVA: 0x007A9624 File Offset: 0x007A7824
	public override void OnEnd()
	{
		if (this.IsAddAttributeListener)
		{
			BaseAttributeComponent attributeComponent = this.AttributeComponent;
			if (attributeComponent == null)
			{
				return;
			}
			attributeComponent.RemoveListener(EAttributeType.SpecialEnergy1, new Action<EAttributeType, float, float>(this.OnAttributeChanged));
		}
	}

	// Token: 0x0601A1D3 RID: 106963 RVA: 0x007A9650 File Offset: 0x007A7850
	private void InitSpecialEnergy()
	{
		this.SpecialEnergyTypeList.Clear();
		this.UiTagList.Clear();
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		int num = (int)((attributeComponent != null) ? attributeComponent.GetCurrentValue(EAttributeType.SpecialEnergy1) : 0f);
		for (int i = 0; i < 4; i++)
		{
			int num2 = (4 - i - 1) * 2;
			int num3 = (num & 3 << num2) >> num2;
			this.UiTagList.Add(0);
			if (num3 > 0)
			{
				this.SpecialEnergyTypeList.Add(num3);
				int uiTag = this.GetUiTag(i, num3);
				if (uiTag != 0)
				{
					RoleTagComponent tagComponent = this.TagComponent;
					if (tagComponent != null)
					{
						tagComponent.AddTag(new int?(uiTag));
					}
				}
				this.UiTagList[i] = uiTag;
			}
		}
	}

	// Token: 0x0601A1D4 RID: 106964 RVA: 0x007A9700 File Offset: 0x007A7900
	[NullableContext(1)]
	public void ModifySlotSpecialEnergy(int[] numberParams)
	{
		int? num = (numberParams.Length > 1) ? new int?(numberParams[1]) : null;
		if (num == null || !CharacterAttributeTypes.specialEnergyIds.Contains((EAttributeType)num.Value))
		{
			return;
		}
		int? num2 = (numberParams.Length > 2) ? new int?(numberParams[2]) : null;
		if (num2 == null || num2.Value < 0 || num2.Value >= 3)
		{
			return;
		}
		if (num2.Value == 0)
		{
			int removeNum = (numberParams.Length > 3) ? numberParams[3] : 1;
			this.RemoveSlotSpecialEnergy(num.Value, removeNum);
			return;
		}
		this.AddSlotSpecialEnergy(num.Value, num2.Value);
	}

	// Token: 0x0601A1D5 RID: 106965 RVA: 0x007A97B5 File Offset: 0x007A79B5
	public void AddSlotSpecialEnergy(int attributeId, int energyType)
	{
		if (this.SpecialEnergyTypeList.Count == 4)
		{
			this.SpecialEnergyTypeList.RemoveAt(0);
		}
		this.SpecialEnergyTypeList.Add(energyType);
		this.SetSpecialEnergyTag();
		this.SaveSpecialEnergy();
	}

	// Token: 0x0601A1D6 RID: 106966 RVA: 0x007A97EC File Offset: 0x007A79EC
	public void RemoveSlotSpecialEnergy(int attributeId, int removeNum = 1)
	{
		for (int i = 0; i < removeNum; i++)
		{
			if (this.SpecialEnergyTypeList.Count > 0)
			{
				this.SpecialEnergyTypeList.RemoveAt(this.SpecialEnergyTypeList.Count - 1);
			}
		}
		this.SetSpecialEnergyTag();
		this.SaveSpecialEnergy();
	}

	// Token: 0x0601A1D7 RID: 106967 RVA: 0x007A9838 File Offset: 0x007A7A38
	private void SaveSpecialEnergy()
	{
		int num = 0;
		foreach (int num2 in this.SpecialEnergyTypeList)
		{
			num <<= 2;
			num += num2;
		}
		BaseAttributeComponent attributeComponent = this.AttributeComponent;
		if (attributeComponent == null)
		{
			return;
		}
		attributeComponent.SetBaseValue(EAttributeType.SpecialEnergy1, (float)num);
	}

	// Token: 0x0601A1D8 RID: 106968 RVA: 0x007A98A4 File Offset: 0x007A7AA4
	public int GetSpecialEnergyType(int index)
	{
		if (index < 0 || index >= this.SpecialEnergyTypeList.Count)
		{
			return 0;
		}
		return this.SpecialEnergyTypeList[index];
	}

	// Token: 0x0601A1D9 RID: 106969 RVA: 0x007A98C6 File Offset: 0x007A7AC6
	private void OnAttributeChanged(EAttributeType attributeId, float newValue, float oldValue)
	{
		if (newValue == 0f && this.SpecialEnergyTypeList.Count != 0)
		{
			this.SpecialEnergyTypeList.Clear();
		}
	}

	// Token: 0x0601A1DA RID: 106970 RVA: 0x007A98E8 File Offset: 0x007A7AE8
	private void InitSlotEnergyTags()
	{
		if (this.SpecialEnergyTagMap != null)
		{
			return;
		}
		this.SpecialEnergyTagMap = new Dictionary<int, int>();
		int key = 6;
		this.SpecialEnergyTagMap[key] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.1AB"];
		int key2 = 9;
		this.SpecialEnergyTagMap[key2] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.2BA"];
		int key3 = 5;
		this.SpecialEnergyTagMap[key3] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.3AA"];
		int key4 = 10;
		this.SpecialEnergyTagMap[key4] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.4BB"];
		int key5 = 1;
		this.SpecialEnergyTagMap[key5] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.5A"];
		int key6 = 2;
		this.SpecialEnergyTagMap[key6] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.6B"];
		int key7 = 0;
		this.SpecialEnergyTagMap[key7] = GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.结算准备.空"];
	}

	// Token: 0x0601A1DB RID: 106971 RVA: 0x007A99DC File Offset: 0x007A7BDC
	private int? GetSpecialEnergyTag()
	{
		if (this.SpecialEnergyTypeList.Count == 0)
		{
			Dictionary<int, int> specialEnergyTagMap = this.SpecialEnergyTagMap;
			if (specialEnergyTagMap == null)
			{
				return null;
			}
			return new int?(specialEnergyTagMap.GetValueOrDefault(0));
		}
		else if (this.SpecialEnergyTypeList.Count == 1)
		{
			Dictionary<int, int> specialEnergyTagMap2 = this.SpecialEnergyTagMap;
			if (specialEnergyTagMap2 == null)
			{
				return null;
			}
			return new int?(specialEnergyTagMap2.GetValueOrDefault(this.SpecialEnergyTypeList[0]));
		}
		else
		{
			int num = this.SpecialEnergyTypeList.Count - 1;
			int index = num - 1;
			int key = (this.SpecialEnergyTypeList[index] << 2) + this.SpecialEnergyTypeList[num];
			Dictionary<int, int> specialEnergyTagMap3 = this.SpecialEnergyTagMap;
			if (specialEnergyTagMap3 == null)
			{
				return null;
			}
			return new int?(specialEnergyTagMap3.GetValueOrDefault(key));
		}
	}

	// Token: 0x0601A1DC RID: 106972 RVA: 0x007A9A9C File Offset: 0x007A7C9C
	private void SetSpecialEnergyTag()
	{
		int? specialEnergyTag = this.GetSpecialEnergyTag();
		if ((specialEnergyTag == null && this.CurrentTag != null) || specialEnergyTag != null)
		{
			RoleTagComponent tagComponent = this.TagComponent;
			if (tagComponent != null)
			{
				tagComponent.RemoveTag(this.CurrentTag);
			}
			this.CurrentTag = null;
		}
		if (specialEnergyTag != null)
		{
			RoleTagComponent tagComponent2 = this.TagComponent;
			if (tagComponent2 != null)
			{
				tagComponent2.AddTag(new int?(specialEnergyTag.Value));
			}
			this.CurrentTag = new int?(specialEnergyTag.Value);
		}
		for (int i = 0; i < 4; i++)
		{
			int num = this.UiTagList[i];
			int uiTag = this.GetUiTag(i, (i < this.SpecialEnergyTypeList.Count) ? this.SpecialEnergyTypeList[i] : 0);
			if (num == 0 || num != uiTag)
			{
				if (num != 0)
				{
					RoleTagComponent tagComponent3 = this.TagComponent;
					if (tagComponent3 != null)
					{
						tagComponent3.RemoveTag(new int?(num));
					}
				}
				if (uiTag != 0)
				{
					RoleTagComponent tagComponent4 = this.TagComponent;
					if (tagComponent4 != null)
					{
						tagComponent4.AddTag(new int?(uiTag));
					}
				}
				this.UiTagList[i] = uiTag;
			}
		}
	}

	// Token: 0x0601A1DD RID: 106973 RVA: 0x007A9BB8 File Offset: 0x007A7DB8
	private int GetUiTag(int index, int energyType)
	{
		if (energyType == 1)
		{
			switch (index)
			{
			case 0:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.A1"];
			case 1:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.A2"];
			case 2:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.A3"];
			case 3:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.A4"];
			}
		}
		else if (energyType == 2)
		{
			switch (index)
			{
			case 0:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.B1"];
			case 1:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.B2"];
			case 2:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.B3"];
			case 3:
				return GameplayTagDefine.EGameplayTagId["角色.BulingMd10011.卦象.UI标识.B4"];
			}
		}
		return 0;
	}

	// Token: 0x0400D190 RID: 53648
	private const int SLOT_COUNT = 4;

	// Token: 0x0400D191 RID: 53649
	private const int SLOT_BITS = 2;

	// Token: 0x0400D192 RID: 53650
	private const int SLOT_MASK = 3;

	// Token: 0x0400D193 RID: 53651
	private const EAttributeType slotSpecialEnergyType = EAttributeType.SpecialEnergy1;

	// Token: 0x0400D194 RID: 53652
	private Entity EntityRef;

	// Token: 0x0400D195 RID: 53653
	private BaseAttributeComponent AttributeComponent;

	// Token: 0x0400D196 RID: 53654
	private RoleTagComponent TagComponent;

	// Token: 0x0400D197 RID: 53655
	private CharacterActorComponent ActorComponent;

	// Token: 0x0400D198 RID: 53656
	[Nullable(1)]
	private readonly List<int> SpecialEnergyTypeList = new List<int>();

	// Token: 0x0400D199 RID: 53657
	private Dictionary<int, int> SpecialEnergyTagMap;

	// Token: 0x0400D19A RID: 53658
	private bool IsAddAttributeListener;

	// Token: 0x0400D19B RID: 53659
	private int? CurrentTag;

	// Token: 0x0400D19C RID: 53660
	[Nullable(1)]
	private readonly List<int> UiTagList = new List<int>();

	// Token: 0x020093CE RID: 37838
	[NullableContext(0)]
	private enum ESlotEnergyType
	{
		// Token: 0x04031266 RID: 201318
		Empty,
		// Token: 0x04031267 RID: 201319
		EnergyA,
		// Token: 0x04031268 RID: 201320
		EnergyB,
		// Token: 0x04031269 RID: 201321
		Max
	}
}
