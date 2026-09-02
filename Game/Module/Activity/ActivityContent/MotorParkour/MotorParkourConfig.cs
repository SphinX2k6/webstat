using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MotorParkour
{
	// Token: 0x020066AF RID: 26287
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MotorParkourConfig : ConfigBase<MotorParkourConfig>
	{
		// Token: 0x06041A62 RID: 268898 RVA: 0x010D526F File Offset: 0x010D346F
		public IReadOnlyList<MotorParkour> GetMotorParkourLevelByActivityId(int activityId)
		{
			return ConfigMotorParkourByActivityId.GetConfigList(activityId, true) ?? Array.Empty<MotorParkour>();
		}

		// Token: 0x06041A63 RID: 268899 RVA: 0x010D5281 File Offset: 0x010D3481
		public MotorParkour? GetMotorParkourLevelById(int id)
		{
			return ConfigMotorParkourById.GetConfig(id, true);
		}

		// Token: 0x06041A64 RID: 268900 RVA: 0x010D528A File Offset: 0x010D348A
		public MotorParkour? GetMotorParkourLevelByInstId(int instId)
		{
			return ConfigMotorParkourByInstId.GetConfig(instId, true);
		}

		// Token: 0x06041A65 RID: 268901 RVA: 0x010D5293 File Offset: 0x010D3493
		public MotorParkourReward? GetMotorParkourTaskById(int id)
		{
			return ConfigMotorParkourRewardById.GetConfig(id, true);
		}

		// Token: 0x06041A66 RID: 268902 RVA: 0x010D529C File Offset: 0x010D349C
		public MotorParkourRecord? GetMotorParkourRecordById(int id)
		{
			MotorParkourRecord? config = ConfigMotorParkourRecordById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorParkour;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托跑酷记录配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x06041A67 RID: 268903 RVA: 0x010D52F4 File Offset: 0x010D34F4
		public MotorParkourNPC? GetMotorParkourNpcById(int id)
		{
			MotorParkourNPC? config = ConfigMotorParkourNPCById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorParkour;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托跑酷npc配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x06041A68 RID: 268904 RVA: 0x010D534C File Offset: 0x010D354C
		public MotorParkourRank? GetMotorParkourRankById(int id)
		{
			MotorParkourRank? config = ConfigMotorParkourRankById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MotorParkour;
				ELogAuthor author = ELogAuthor.CXJ;
				string message = "摩托跑酷排名配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}
	}
}
