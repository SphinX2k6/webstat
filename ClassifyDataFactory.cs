using System;
using System.Runtime.CompilerServices;

// Token: 0x02002868 RID: 10344
[NullableContext(1)]
[Nullable(0)]
public static class ClassifyDataFactory
{
	// Token: 0x060147E5 RID: 83941 RVA: 0x005AF856 File Offset: 0x005ADA56
	public static RoleFavorActionClassifyData CreateClassifyData(string titleTableId, EFavorTabType favorTabType, int roleId, EFavorActionType typeParam)
	{
		if (favorTabType == EFavorTabType.Action)
		{
			return new RoleFavorActionClassifyData(titleTableId, roleId, typeParam);
		}
		throw new Exception("不支持的好感度类型");
	}

	// Token: 0x060147E6 RID: 83942 RVA: 0x005AF86F File Offset: 0x005ADA6F
	public static RoleFavorExperienceClassifyData CreateClassifyData(string titleTableId, EFavorTabType favorTabType, int roleId, EFavorExperienceType typeParam)
	{
		if (favorTabType == EFavorTabType.Experience)
		{
			return new RoleFavorExperienceClassifyData(titleTableId, roleId, typeParam);
		}
		throw new Exception("不支持的好感度类型");
	}

	// Token: 0x060147E7 RID: 83943 RVA: 0x005AF888 File Offset: 0x005ADA88
	public static RoleFavorPreciousItemClassifyData CreateClassifyData(string titleTableId, EFavorTabType favorTabType, int roleId)
	{
		if (favorTabType == EFavorTabType.PreciousItem)
		{
			return new RoleFavorPreciousItemClassifyData(titleTableId, roleId);
		}
		throw new Exception("不支持的好感度类型");
	}

	// Token: 0x060147E8 RID: 83944 RVA: 0x005AF8A0 File Offset: 0x005ADAA0
	public static RoleFavorVoiceClassifyData CreateClassifyData(string titleTableId, EFavorTabType favorTabType, int roleId, EFavorVoiceType typeParam)
	{
		if (favorTabType == EFavorTabType.Voice)
		{
			return new RoleFavorVoiceClassifyData(titleTableId, roleId, typeParam);
		}
		throw new Exception("不支持的好感度类型");
	}

	// Token: 0x060147E9 RID: 83945 RVA: 0x005AF8B8 File Offset: 0x005ADAB8
	public static RoleFavorClassifyDataBase CreateClassifyData(string titleTableId, EFavorTabType favorTabType, int roleId, [Nullable(2)] object typeParam = null)
	{
		switch (favorTabType)
		{
		case EFavorTabType.Voice:
			return new RoleFavorVoiceClassifyData(titleTableId, roleId, (EFavorVoiceType)typeParam);
		case EFavorTabType.Experience:
			return new RoleFavorExperienceClassifyData(titleTableId, roleId, (EFavorExperienceType)typeParam);
		case EFavorTabType.Action:
			return new RoleFavorActionClassifyData(titleTableId, roleId, (EFavorActionType)typeParam);
		case EFavorTabType.PreciousItem:
			return new RoleFavorPreciousItemClassifyData(titleTableId, roleId);
		default:
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Role;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "不支持的好感度类型";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("favorTabType", favorTabType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			throw new Exception("不支持的好感度类型");
		}
		}
	}
}
