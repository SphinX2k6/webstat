using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02003166 RID: 12646
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeaponComponentConfig : ConfigBase<WeaponComponentConfig>
{
	// Token: 0x0601A378 RID: 107384 RVA: 0x007B44E4 File Offset: 0x007B26E4
	public WeaponVisibleConfig? GetWeaponVisibleConfig(Entity entity)
	{
		CreatureDataComponent component = entity.GetComponent<CreatureDataComponent>();
		if (component == null)
		{
			return null;
		}
		int pbDataId = component.GetPbDataId();
		return this.GetWeaponVisibleConfigById(pbDataId);
	}

	// Token: 0x0601A379 RID: 107385 RVA: 0x007B4513 File Offset: 0x007B2713
	public WeaponVisibleConfig? GetWeaponVisibleConfigById(int configId)
	{
		return ConfigWeaponVisibleConfigByIdWithZero.GetConfig(configId, configId, configId, true);
	}

	// Token: 0x0601A37A RID: 107386 RVA: 0x007B4520 File Offset: 0x007B2720
	public int[] GetHideWeaponTags(int configId)
	{
		string[] array = ConfigWeaponHideConfigByIdWithZero.GetConfig(configId, configId, configId, true).Value.HideWeaponTags();
		int[] array2 = new int[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			string tagName = array[i];
			array2[i] = GameplayTagUtils.GetTagIdByName(tagName);
		}
		return array2;
	}
}
