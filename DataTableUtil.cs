using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Interface;

// Token: 0x02000C0A RID: 3082
[NullableContext(1)]
[Nullable(0)]
public class DataTableUtil : IStaticVariableResetter
{
	// Token: 0x0600331A RID: 13082 RVA: 0x000278B0 File Offset: 0x00025AB0
	static DataTableUtil()
	{
		Dictionary<EDataTable, string> dictionary = new Dictionary<EDataTable, string>();
		dictionary[EDataTable.ModelConfig] = "/Game/Aki/Data/Entity/CDT_ModelConfig.CDT_ModelConfig";
		dictionary[EDataTable.EntityProperty] = "/Game/Aki/Data/Fight/DT_EntityProperty.DT_EntityProperty";
		dictionary[EDataTable.AiWeaponSocket] = "/Game/Aki/Character/Monster/Common/Data/DT_AiWeaponSocket.DT_AiWeaponSocket";
		dictionary[EDataTable.RoleQualityInfo] = "/Game/Aki/Data/Role/DT_RoleQualityInfo.DT_RoleQualityInfo";
		dictionary[EDataTable.CipherGameplay] = "/Game/Aki/GamePlay/Cipher/DT_SCipherGameplay.DT_SCipherGameplay";
		dictionary[EDataTable.ConditionGroup] = "/Game/Aki/Data/Condition/DT_ConditionGroup.DT_ConditionGroup";
		dictionary[EDataTable.HitMapping] = "/Game/Aki/Data/Fight/DT_HitMapping.DT_HitMapping";
		dictionary[EDataTable.InteractionConfigs] = "/Game/Aki/Data/Interaction/CDT_InteractionConfigs.CDT_InteractionConfigs";
		dictionary[EDataTable.ManipulateItem] = "/Game/Aki/Data/Manipulate/Item/DT_Manipulate_Item.DT_Manipulate_Item";
		dictionary[EDataTable.ManipulatePrecast] = "/Game/Aki/Data/Manipulate/Precast/DT_Manipulate_Precast.DT_Manipulate_Precast";
		dictionary[EDataTable.Parkour] = "/Game/Aki/Data/Parkour/DT_Parkour.DT_Parkour";
		dictionary[EDataTable.SceneDecorativeUi] = "/Game/Aki/Data/Scene3DUI/DT_SceneDecorativeUI.DT_SceneDecorativeUI";
		dictionary[EDataTable.SceneUiTag] = "/Game/Aki/Data/Scene3DUI/DT_SceneUITag.DT_SceneUITag";
		dictionary[EDataTable.ServerInfo] = "/Game/Aki/Data/Server/DT_ServerInfo.DT_ServerInfo";
		dictionary[EDataTable.UiCameraAnimationBlendSettings] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraAnimationBlendSettings.DT_UiCameraAnimationBlendSettings";
		dictionary[EDataTable.UiCameraAnimationSettings] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraSetting.DT_UiCameraSetting";
		dictionary[EDataTable.Vision] = "/Game/Aki/Character/Vision/DT_Vision.DT_Vision";
		dictionary[EDataTable.UiRoleCameraSettings] = "/Game/Aki/Data/UiRoleCamera/DT_UiRoleCameraSettings.DT_UiRoleCameraSettings";
		dictionary[EDataTable.UiRoleCameraOffsetSettings] = "/Game/Aki/Data/UiRoleCamera/DT_UiRoleCameraOffsetSettings.DT_UiRoleCameraOffsetSettings";
		dictionary[EDataTable.Footprint] = "/Game/Aki/Character/Role/Common/Data/DT/DT_Footprint.DT_Footprint";
		dictionary[EDataTable.SCharacterFootPrint] = "/Game/Aki/Character/Role/Common/Data/DT/DT_CharacterFootprint.DT_CharacterFootprint";
		dictionary[EDataTable.SequenceMember] = "/Game/Aki/Sequence/Manager/DT_SequenceMember.DT_SequenceMember";
		dictionary[EDataTable.GachaWeaponTransform] = "/Game/Aki/Data/GaCha/GachaWeaponTransform.GachaWeaponTransform";
		dictionary[EDataTable.FightSettlementCamera] = "/Game/Aki/Data/Camera/DT_FightSettlementCamera.DT_FightSettlementCamera";
		dictionary[EDataTable.InputCommandTransform] = "/Game/Aki/Data/Fight/DT_InputCommandTransform.DT_InputCommandTransform";
		dictionary[EDataTable.FreeCameraConfig] = "/Game/Aki/Data/Camera/DT_FreeCameraConfigList.DT_FreeCameraConfigList";
		dictionary[EDataTable.FightPhotographCameraConfig] = "/Game/Aki/Data/UiCameraAnimation/DT_UiCameraFightPhotographSetting.DT_UiCameraFightPhotographSetting";
		dictionary[EDataTable.DestructibleTable] = "/Game/Aki/Data/Level/Destructible/DestructibleTable.DestructibleTable";
		dictionary[EDataTable.GameplayABP] = "/Game/Aki/Data/Character/DT_GameplayABPConfig.DT_GameplayABPConfig";
		dictionary[EDataTable.DecorationConfig] = "/Game/Aki/Data/Entity/CDT_DecorationConfig.CDT_DecorationConfig";
		dictionary[EDataTable.UiModelRotateSettings] = "/Game/Aki/Data/UiModel/DT_UiModelRotateSetting.DT_UiModelRotateSetting";
		DataTableUtil.dataTablePaths = dictionary;
		StaticVariableRegister.RegisterAndExecute(new Action(DataTableUtil.CreateStaticDefaultValue), new Action(DataTableUtil.ResetStaticDefaultValue));
	}

	// Token: 0x0600331B RID: 13083 RVA: 0x00027A70 File Offset: 0x00025C70
	[NullableContext(0)]
	public unsafe static bool TryGetDataTableRowStruct<[IsUnmanaged] T>([Nullable(2)] UDataTable table, [Nullable(1)] string rowName, out T? value) where T : struct, ValueType, IUnrealScriptStruct
	{
		if (table == null || string.IsNullOrEmpty(rowName))
		{
			value = null;
			return false;
		}
		IntPtr dataTableRowFromName = FKuroDataTableFunctionLibrary.GetDataTableRowFromName(table, rowName);
		if (dataTableRowFromName == IntPtr.Zero)
		{
			value = null;
			return false;
		}
		T* ptr = (T*)dataTableRowFromName.ToPointer();
		value = new T?(*ptr);
		return true;
	}

	// Token: 0x0600331C RID: 13084 RVA: 0x00027AC4 File Offset: 0x00025CC4
	[NullableContext(0)]
	public unsafe static bool TryGetDataTableRowStruct<[IsUnmanaged] T>(EDataTable dtEnum, [Nullable(1)] string rowName, out T? value) where T : struct, ValueType, IUnrealScriptStruct
	{
		UDataTable dataTable = DataTableUtil.GetDataTable(dtEnum);
		if (dataTable == null || string.IsNullOrEmpty(rowName))
		{
			value = null;
			return false;
		}
		IntPtr dataTableRowFromName = FKuroDataTableFunctionLibrary.GetDataTableRowFromName(dataTable, rowName);
		if (dataTableRowFromName == IntPtr.Zero)
		{
			value = null;
			return false;
		}
		T* ptr = (T*)dataTableRowFromName.ToPointer();
		value = new T?(*ptr);
		return true;
	}

	// Token: 0x0600331D RID: 13085 RVA: 0x00027B20 File Offset: 0x00025D20
	[return: Nullable(2)]
	public static T GetDataTableRow<[Nullable(0)] T>([Nullable(2)] UDataTable table, string rowName) where T : UnrealProxyObject
	{
		if (table == null || string.IsNullOrEmpty(rowName))
		{
			return default(T);
		}
		Type typeFromHandle = typeof(T);
		T t;
		if (Singleton<DataTableCacheData>.Instance.TryGet<T>(table, rowName, out t))
		{
			return t;
		}
		IntPtr dataTableRowFromName = FKuroDataTableFunctionLibrary.GetDataTableRowFromName(table, rowName);
		if (dataTableRowFromName == IntPtr.Zero)
		{
			return default(T);
		}
		t = (T)((object)Activator.CreateInstance(typeFromHandle, new object[]
		{
			dataTableRowFromName,
			table
		}));
		if (Singleton<DataTableCacheData>.Instance.Add<T>(table, rowName, t))
		{
			return t;
		}
		return default(T);
	}

	// Token: 0x0600331E RID: 13086 RVA: 0x00027BB8 File Offset: 0x00025DB8
	[return: Nullable(2)]
	public static T GetDataTableRowFromName<[Nullable(0)] T>(EDataTable dtEnum, string rowName) where T : UnrealProxyObject
	{
		UDataTable dataTable = DataTableUtil.GetDataTable(dtEnum);
		if (dataTable == null || string.IsNullOrEmpty(rowName))
		{
			return default(T);
		}
		Type typeFromHandle = typeof(T);
		T t;
		if (Singleton<DataTableCacheData>.Instance.TryGet<T>(dataTable, rowName, out t))
		{
			return t;
		}
		IntPtr dataTableRowFromName = FKuroDataTableFunctionLibrary.GetDataTableRowFromName(dataTable, rowName);
		if (dataTableRowFromName == IntPtr.Zero)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DataTableUtil;
			ELogAuthor author = ELogAuthor.LZK;
			string message = "获取预加载DT行配置失败";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RowName", rowName);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return default(T);
		}
		t = (T)((object)Activator.CreateInstance(typeFromHandle, new object[]
		{
			dataTableRowFromName,
			dataTable
		}));
		if (Singleton<DataTableCacheData>.Instance.Add<T>(dataTable, rowName, t))
		{
			return t;
		}
		return default(T);
	}

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x0600331F RID: 13087 RVA: 0x00027C83 File Offset: 0x00025E83
	private static Dictionary<EDataTable, UDataTable> DataTableCacheMap
	{
		get
		{
			return DataTableUtil._dataTableCacheMap;
		}
	}

	// Token: 0x06003320 RID: 13088 RVA: 0x00027C8C File Offset: 0x00025E8C
	[NullableContext(2)]
	private static UDataTable GetDataTable(EDataTable dtEnum)
	{
		UDataTable loadedAsset;
		if (DataTableUtil.DataTableCacheMap.TryGetValue(dtEnum, out loadedAsset))
		{
			return loadedAsset;
		}
		string text;
		if (!DataTableUtil.dataTablePaths.TryGetValue(dtEnum, out text))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.DataTableUtil;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "所获取的DT不在DataTableUtil管理中";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("DTEnum", dtEnum);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		loadedAsset = Singleton<ResourceSystem>.Instance.GetLoadedAsset<UDataTable>(text);
		if (loadedAsset == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.DataTableUtil;
			ELogAuthor author2 = ELogAuthor.WLJ;
			string message2 = "获取预加载DT失败,请检查是否在预加载前访问该接口";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("DTPath", text);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		else
		{
			DataTableUtil.DataTableCacheMap[dtEnum] = loadedAsset;
		}
		return loadedAsset;
	}

	// Token: 0x06003321 RID: 13089 RVA: 0x00027D34 File Offset: 0x00025F34
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public static TArray<string> GetDataTableAllRowNames(EDataTable dtEnum)
	{
		UDataTable dataTable = DataTableUtil.GetDataTable(dtEnum);
		if (dataTable == null)
		{
			return null;
		}
		IntPtr dataTableAllRowNames = FKuroDataTableFunctionLibrary.GetDataTableAllRowNames(dataTable);
		if (dataTableAllRowNames == IntPtr.Zero)
		{
			return null;
		}
		return new TArray<string>(dataTableAllRowNames, true, false);
	}

	// Token: 0x06003322 RID: 13090 RVA: 0x00027D68 File Offset: 0x00025F68
	public static void GetDataTableAllRowNamesFromTable([Nullable(2)] UDataTable table, List<string> result)
	{
		if (table == null)
		{
			return;
		}
		IntPtr dataTableAllRowNames = FKuroDataTableFunctionLibrary.GetDataTableAllRowNames(table);
		if (dataTableAllRowNames == IntPtr.Zero)
		{
			return;
		}
		result.Clear();
		TArray<FName> tarray = new TArray<FName>(dataTableAllRowNames, true, false);
		for (int i = 0; i < tarray.Num(); i++)
		{
			FName? fname = new FName?(tarray[i]);
			if (fname != null)
			{
				result.Add(fname.ToString());
			}
		}
	}

	// Token: 0x06003323 RID: 13091 RVA: 0x00027DD4 File Offset: 0x00025FD4
	public static List<T> GetDataTableAllRow<[Nullable(0)] T>(EDataTable dtEnum) where T : UnrealScriptStructProxy, IUnrealScriptStructProxy
	{
		List<T> list = new List<T>();
		UDataTable dataTable = DataTableUtil.GetDataTable(dtEnum);
		if (dataTable == null)
		{
			return list;
		}
		IntPtr[] dataTableAllRows = FKuroDataTableFunctionLibrary.GetDataTableAllRows(dataTable);
		if (dataTableAllRows.Length == 0)
		{
			return list;
		}
		foreach (IntPtr intPtr in dataTableAllRows)
		{
			if (intPtr != IntPtr.Zero)
			{
				T t = (T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					intPtr,
					dataTable
				}));
				if (t != null)
				{
					list.Add(t);
				}
			}
		}
		return list;
	}

	// Token: 0x06003324 RID: 13092 RVA: 0x00027E60 File Offset: 0x00026060
	public static List<T> GetDataTableAllRowFromTable<[Nullable(0)] T>([Nullable(2)] UDataTable table) where T : UnrealScriptStructProxy
	{
		List<T> list = new List<T>();
		if (table == null)
		{
			return list;
		}
		List<string> list2 = new List<string>();
		DataTableUtil.GetDataTableAllRowNamesFromTable(table, list2);
		for (int i = 0; i < list2.Count; i++)
		{
			string rowName = list2[i];
			T dataTableRow = DataTableUtil.GetDataTableRow<T>(table, rowName);
			if (dataTableRow != null)
			{
				list.Add(dataTableRow);
			}
		}
		return list;
	}

	// Token: 0x06003325 RID: 13093 RVA: 0x00027EC0 File Offset: 0x000260C0
	public static void GetDataTableAllRowWithKeysFromTable<[Nullable(0)] T>([Nullable(2)] UDataTable table, List<DataTableKeyRow<T>> result) where T : UnrealScriptStructProxy
	{
		if (table == null)
		{
			return;
		}
		TArray<FName> tarray = new TArray<FName>();
		IntPtr nativePtr = tarray.NativePtr;
		IntPtr[] array = new IntPtr[0];
		FKuroDataTableFunctionLibrary.GetDataTableAllRowWithKeys(table, ref nativePtr, ref array);
		if (nativePtr == IntPtr.Zero || array.Length == 0)
		{
			return;
		}
		if (tarray.Num() != array.Length)
		{
			return;
		}
		result.Clear();
		for (int i = 0; i < tarray.Num(); i++)
		{
			FName? fname = new FName?(tarray[i]);
			IntPtr intPtr = array[i];
			if (fname != null && intPtr != IntPtr.Zero)
			{
				T dataTableRow = DataTableUtil.GetDataTableRow<T>(table, fname.Value.ToString());
				if (dataTableRow != null)
				{
					DataTableKeyRow<T> item = new DataTableKeyRow<T>(fname.ToString(), dataTableRow);
					result.Add(item);
				}
			}
		}
	}

	// Token: 0x06003326 RID: 13094 RVA: 0x00027F90 File Offset: 0x00026190
	public unsafe static List<Tuple<string, T>> GetAllDataTableRowFromTableWithRowName<[Nullable(0)] T>([Nullable(2)] UDataTable table) where T : UnrealScriptStructProxy
	{
		List<Tuple<string, T>> list = new List<Tuple<string, T>>();
		if (table == null)
		{
			return list;
		}
		List<string> list2 = new List<string>();
		DataTableUtil.GetDataTableAllRowNamesFromTable(table, list2);
		foreach (string text in list2)
		{
			T dataTableRow = DataTableUtil.GetDataTableRow<T>(table, text);
			if (dataTableRow == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DataTableUtil;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "[GetAllDataTableRowFromTableWithRowName]GetRowValue Failed";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Table", table);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", text);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				list.Add(Tuple.Create<string, T>(text, dataTableRow));
			}
		}
		return list;
	}

	// Token: 0x06003327 RID: 13095 RVA: 0x00028078 File Offset: 0x00026278
	[return: Nullable(2)]
	public static SWeaponSocketItem LoadAiWeaponSocketConfigs(string rowName, int key)
	{
		SAiWeaponSocket dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SAiWeaponSocket>(EDataTable.AiWeaponSocket, rowName);
		if (dataTableRowFromName == null)
		{
			return null;
		}
		SWeaponSocket valueOrDefault = dataTableRowFromName.AiModelConfig.GetValueOrDefault(key);
		if (valueOrDefault == null)
		{
			return null;
		}
		return valueOrDefault.Weapon;
	}

	// Token: 0x06003328 RID: 13096 RVA: 0x000280B0 File Offset: 0x000262B0
	public static Dictionary<int, SAiWeaponSocket> LoadAllAiWeaponSockets()
	{
		Dictionary<int, SAiWeaponSocket> dictionary = new Dictionary<int, SAiWeaponSocket>();
		List<string> list = new List<string>();
		UDataTable dataTable = DataTableUtil.GetDataTable(EDataTable.AiWeaponSocket);
		if (dataTable == null)
		{
			return dictionary;
		}
		DataTableUtil.GetDataTableAllRowNamesFromTable(dataTable, list);
		foreach (string text in list)
		{
			SAiWeaponSocket dataTableRowFromName = DataTableUtil.GetDataTableRowFromName<SAiWeaponSocket>(EDataTable.AiWeaponSocket, text);
			if (dataTableRowFromName != null)
			{
				dictionary[int.Parse(text)] = dataTableRowFromName;
			}
		}
		return dictionary;
	}

	// Token: 0x06003329 RID: 13097 RVA: 0x0002813C File Offset: 0x0002633C
	public static void CreateStaticDefaultValue()
	{
		DataTableUtil._dataTableCacheMap = new Dictionary<EDataTable, UDataTable>();
	}

	// Token: 0x0600332A RID: 13098 RVA: 0x00028148 File Offset: 0x00026348
	public static void ResetStaticDefaultValue()
	{
		DataTableUtil._dataTableCacheMap = null;
	}

	// Token: 0x040005D8 RID: 1496
	public static readonly IReadOnlyDictionary<EDataTable, string> dataTablePaths;

	// Token: 0x040005D9 RID: 1497
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<EDataTable, UDataTable> _dataTableCacheMap;
}
