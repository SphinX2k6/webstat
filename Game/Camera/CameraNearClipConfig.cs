using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Camera
{
	// Token: 0x0200709B RID: 28827
	public class CameraNearClipConfig : IStaticVariableResetter
	{
		// Token: 0x06045DC4 RID: 286148 RVA: 0x0124B789 File Offset: 0x01249989
		static CameraNearClipConfig()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(CameraNearClipConfig.CreateStaticDefaultValue), new Action(CameraNearClipConfig.ResetStaticDefaultValue));
		}

		// Token: 0x06045DC5 RID: 286149 RVA: 0x0124B7A8 File Offset: 0x012499A8
		public CameraNearClipConfig(int priority)
		{
			this.Priority = priority;
			this.Id = ++CameraNearClipConfig._instanceId;
		}

		// Token: 0x06045DC6 RID: 286150 RVA: 0x0124B7CA File Offset: 0x012499CA
		public bool IsValid()
		{
			return true;
		}

		// Token: 0x06045DC7 RID: 286151 RVA: 0x0124B7CD File Offset: 0x012499CD
		public int SetRelativeNearClip(ECameraRelativeNearClipTargetType targetType, float distance)
		{
			this.Type = ECameraNearClipType.Relative;
			this.CameraBaseNearClip = new CameraRelativeNearClipConfig(targetType, distance);
			return this.Id;
		}

		// Token: 0x06045DC8 RID: 286152 RVA: 0x0124B7E9 File Offset: 0x012499E9
		public int SetAbsoluteNearClip(float distance)
		{
			this.Type = ECameraNearClipType.Absolute;
			this.CameraBaseNearClip = new CameraAbsoluteNearClipConfig(distance);
			return this.Id;
		}

		// Token: 0x06045DC9 RID: 286153 RVA: 0x0124B804 File Offset: 0x01249A04
		public static void CreateStaticDefaultValue()
		{
			CameraNearClipConfig._instanceId = 0;
		}

		// Token: 0x06045DCA RID: 286154 RVA: 0x0124B80C File Offset: 0x01249A0C
		public static void ResetStaticDefaultValue()
		{
			CameraNearClipConfig._instanceId = 0;
		}

		// Token: 0x040271FE RID: 160254
		private static int _instanceId;

		// Token: 0x040271FF RID: 160255
		public readonly int Id;

		// Token: 0x04027200 RID: 160256
		public bool MarkDelete;

		// Token: 0x04027201 RID: 160257
		public ECameraNearClipType Type;

		// Token: 0x04027202 RID: 160258
		[Nullable(2)]
		public CameraBaseNearClipConfig CameraBaseNearClip;

		// Token: 0x04027203 RID: 160259
		public readonly int Priority;
	}
}
