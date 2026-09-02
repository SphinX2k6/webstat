using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x02006169 RID: 24937
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleVolumeInfo
	{
		// Token: 0x0603F03A RID: 258106 RVA: 0x010281AB File Offset: 0x010263AB
		public RoleVolumeInfo(int roleId, int entityId)
		{
			this.RoleId = roleId;
			this.EntityId = entityId;
			this.TimeValue = Singleton<Time>.Instance.Now;
		}

		// Token: 0x0603F03B RID: 258107 RVA: 0x010281E7 File Offset: 0x010263E7
		public double GetDistSquared()
		{
			return this.DistSquared;
		}

		// Token: 0x0603F03C RID: 258108 RVA: 0x010281F0 File Offset: 0x010263F0
		public void UpdateDistSquared(double value)
		{
			this.DistSquared = Math.Min(value, RoleAudioVolumeInfo.MaxDistanceSquared);
			if (Math.Abs(this.DistSquared - RoleAudioVolumeInfo.MaxDistanceSquared) < 0.0001)
			{
				this.Priority = EEventVolumePriority.Mute;
				return;
			}
			this.Priority = ((this.DistSquared < RoleAudioVolumeInfo.SplitDistanceSquared) ? EEventVolumePriority.Top : EEventVolumePriority.Second);
		}

		// Token: 0x0603F03D RID: 258109 RVA: 0x01028249 File Offset: 0x01026449
		public void AddEvent(int handle, EventVolumeInfo info)
		{
			this.EventList[handle] = info;
			info.OnChangeVolume(this.Volume, this);
		}

		// Token: 0x0603F03E RID: 258110 RVA: 0x01028265 File Offset: 0x01026465
		public void RemoveEvent(int handle)
		{
			this.EventList.Remove(handle);
		}

		// Token: 0x0603F03F RID: 258111 RVA: 0x01028274 File Offset: 0x01026474
		public void SetPlayEvent(bool result)
		{
			if (result)
			{
				this.TimeValue = Singleton<Time>.Instance.Now;
			}
			this.IsCurrentRole = result;
			this.ChangeVolume((result > false) ? 1 : 0);
		}

		// Token: 0x0603F040 RID: 258112 RVA: 0x0102829A File Offset: 0x0102649A
		public bool Empty()
		{
			return this.EventList.Count == 0;
		}

		// Token: 0x0603F041 RID: 258113 RVA: 0x010282AC File Offset: 0x010264AC
		private void ChangeVolume(int volume)
		{
			this.Volume = volume;
			foreach (KeyValuePair<int, EventVolumeInfo> keyValuePair in this.EventList)
			{
				keyValuePair.Value.OnChangeVolume(volume, this);
			}
		}

		// Token: 0x0603F042 RID: 258114 RVA: 0x01028310 File Offset: 0x01026510
		public static int Compare(RoleVolumeInfo a, RoleVolumeInfo b)
		{
			if (a.Priority == b.Priority)
			{
				EEventVolumePriority priority = a.Priority;
				if (priority != EEventVolumePriority.Second)
				{
					if (priority == EEventVolumePriority.Top)
					{
						double num = b.TimeValue - a.TimeValue;
						if (num == 0.0)
						{
							num -= 1.0;
						}
						return Math.Sign(num);
					}
				}
				else
				{
					if (a.IsCurrentRole)
					{
						return Math.Sign(a.GetDistSquared() * RoleAudioVolumeInfo.CorrectionRatio - b.GetDistSquared());
					}
					if (b.IsCurrentRole)
					{
						return Math.Sign(a.GetDistSquared() - b.GetDistSquared() * RoleAudioVolumeInfo.CorrectionRatio);
					}
					double num2 = a.GetDistSquared() - b.GetDistSquared();
					if (num2 < 0.0001)
					{
						num2 -= 1.0;
					}
					return Math.Sign(num2);
				}
			}
			int num3 = b.Priority - a.Priority;
			if (num3 == 0)
			{
				num3--;
			}
			return num3;
		}

		// Token: 0x040235B3 RID: 144819
		private int Volume;

		// Token: 0x040235B4 RID: 144820
		private double DistSquared = RoleAudioVolumeInfo.MaxDistanceSquared;

		// Token: 0x040235B5 RID: 144821
		private readonly Dictionary<int, EventVolumeInfo> EventList = new Dictionary<int, EventVolumeInfo>();

		// Token: 0x040235B6 RID: 144822
		public bool IsCurrentRole;

		// Token: 0x040235B7 RID: 144823
		public int RoleId;

		// Token: 0x040235B8 RID: 144824
		public int EntityId;

		// Token: 0x040235B9 RID: 144825
		public double TimeValue;

		// Token: 0x040235BA RID: 144826
		public EEventVolumePriority Priority;
	}
}
