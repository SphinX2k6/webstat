using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x020034C2 RID: 13506
public class WorldEnvironmentInfo
{
	// Token: 0x170026B8 RID: 9912
	// (get) Token: 0x0601C8B6 RID: 116918 RVA: 0x0088F3E9 File Offset: 0x0088D5E9
	public EDataLayerType DataLayerType
	{
		get
		{
			return this.DataLayer;
		}
	}

	// Token: 0x170026B9 RID: 9913
	// (get) Token: 0x0601C8B7 RID: 116919 RVA: 0x0088F3F1 File Offset: 0x0088D5F1
	public ESubDataLayerType SubDataLayerType
	{
		get
		{
			return this.SubDataLayer;
		}
	}

	// Token: 0x170026BA RID: 9914
	// (get) Token: 0x0601C8B8 RID: 116920 RVA: 0x0088F3F9 File Offset: 0x0088D5F9
	// (set) Token: 0x0601C8B9 RID: 116921 RVA: 0x0088F401 File Offset: 0x0088D601
	public EActorCavernMode GlobalCaveMode
	{
		get
		{
			return this.GlobalCaveModeInternal;
		}
		private set
		{
			if (this.GlobalCaveModeInternal == value)
			{
				return;
			}
			this.GlobalCaveModeInternal = value;
			this.RequestUpdateVoxelEnv();
		}
	}

	// Token: 0x0601C8BA RID: 116922 RVA: 0x0088F41C File Offset: 0x0088D61C
	public void RequestUpdateVoxelEnv()
	{
		if (this.GlobalCaveModeInternal == this.ServerCaveMode)
		{
			return;
		}
		if (Singleton<Time>.Instance.Now - this.LastUpdateTime < 1000.0)
		{
			return;
		}
		PlayerVoxelEnvRequest playerVoxelEnvRequest = PlayerVoxelEnvRequest.Create();
		playerVoxelEnvRequest.VoxelEnv = (int)this.GlobalCaveModeInternal;
		Singleton<Net>.Instance.Call<PlayerVoxelEnvResponse>(ERequestMessageId.PlayerVoxelEnvRequest, playerVoxelEnvRequest, delegate(PlayerVoxelEnvResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.PlayerVoxelEnvResponse, null, true, true);
				return;
			}
			this.ServerCaveMode = (EActorCavernMode)response.VoxelEnv;
		}, 0);
		this.LastUpdateTime = Singleton<Time>.Instance.Now;
	}

	// Token: 0x0601C8BB RID: 116923 RVA: 0x0088F494 File Offset: 0x0088D694
	public bool IsEqual(long type)
	{
		return (long)this.Type == type;
	}

	// Token: 0x0601C8BC RID: 116924 RVA: 0x0088F4A0 File Offset: 0x0088D6A0
	public bool IsEnCloseEnvironment()
	{
		return (long)this.Type == 0L || (long)this.Type == 1L;
	}

	// Token: 0x170026BB RID: 9915
	// (get) Token: 0x0601C8BD RID: 116925 RVA: 0x0088F4B8 File Offset: 0x0088D6B8
	public int EnvType
	{
		get
		{
			return this.Type;
		}
	}

	// Token: 0x0601C8BE RID: 116926 RVA: 0x0088F4C0 File Offset: 0x0088D6C0
	[NullableContext(1)]
	public void SetInfo(FKuroVoxelInfo info)
	{
		switch (info.EnvType)
		{
		case 0:
			this.DataLayer = EDataLayerType.Cave;
			this.SubDataLayer = ESubDataLayerType.Cave;
			this.GlobalCaveMode = EActorCavernMode.ActorCavernMode_Inside;
			break;
		case 1:
			this.DataLayer = EDataLayerType.Room;
			this.SubDataLayer = ESubDataLayerType.Room;
			this.GlobalCaveMode = EActorCavernMode.ActorCavernMode_Inside;
			break;
		case 2:
			this.DataLayer = EDataLayerType.Cave;
			this.SubDataLayer = ESubDataLayerType.Cave;
			this.GlobalCaveMode = EActorCavernMode.ActorCavernMode_IntermediateZone;
			break;
		default:
			this.GlobalCaveMode = EActorCavernMode.ActorCavernMode_Outside;
			break;
		}
		this.Type = (int)info.EnvType;
	}

	// Token: 0x0601C8BF RID: 116927 RVA: 0x0088F540 File Offset: 0x0088D740
	public void ResetInfo()
	{
		this.Type = 255;
		UKuroGameBudgetAllocatorCSharpInterface.SetGlobalCavernMode(EActorCavernMode.ActorCavernMode_Outside);
		UWorld world = GlobalData.World;
		if (world == null || !world.IsValid())
		{
			return;
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(EDataLayerType.Cave.ToEnumString());
		FName? dynamicFName2 = FNameUtil.GetDynamicFName(ESubDataLayerType.Cave.ToEnumString());
		ControllerBase<WorldController>.Instance.ChangeCaveOrRoomDatalayer(world, dynamicFName, dynamicFName2, false);
	}

	// Token: 0x0400E5E6 RID: 58854
	private int Type = 255;

	// Token: 0x0400E5E7 RID: 58855
	private EDataLayerType DataLayer;

	// Token: 0x0400E5E8 RID: 58856
	private ESubDataLayerType SubDataLayer;

	// Token: 0x0400E5E9 RID: 58857
	private EActorCavernMode GlobalCaveModeInternal = EActorCavernMode.ActorCavernMode_Outside;

	// Token: 0x0400E5EA RID: 58858
	public EActorCavernMode ServerCaveMode = EActorCavernMode.ActorCavernMode_Outside;

	// Token: 0x0400E5EB RID: 58859
	private double LastUpdateTime;
}
