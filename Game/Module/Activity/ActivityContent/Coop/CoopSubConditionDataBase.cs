using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Coop
{
	// Token: 0x020069AF RID: 27055
	[NullableContext(1)]
	[Nullable(0)]
	public class CoopSubConditionDataBase
	{
		// Token: 0x06043172 RID: 274802 RVA: 0x0113B6DE File Offset: 0x011398DE
		public CoopSubConditionDataBase(int id, ECoopSubConditionType taskType)
		{
			this.Id = id;
			this.TaskType = taskType;
		}

		// Token: 0x06043173 RID: 274803 RVA: 0x0113B6FF File Offset: 0x011398FF
		public virtual bool IsShowJumpBtn()
		{
			return false;
		}

		// Token: 0x06043174 RID: 274804 RVA: 0x0113B702 File Offset: 0x01139902
		public virtual bool IsTaskDone()
		{
			return false;
		}

		// Token: 0x06043175 RID: 274805 RVA: 0x0113B705 File Offset: 0x01139905
		public virtual void RefreshData(CoopTaskCompleteInfo data)
		{
		}

		// Token: 0x06043176 RID: 274806 RVA: 0x0113B707 File Offset: 0x01139907
		public virtual void OnJumpClick()
		{
		}

		// Token: 0x06043177 RID: 274807 RVA: 0x0113B70C File Offset: 0x0113990C
		public void JumpMapMark(int traceMapId, int traceMarkId)
		{
			MapMark? config = ConfigBase<MapConfig>.Instance.GetConfigMark(traceMarkId);
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Mouse, false, null, delegate(bool success, int viewId)
			{
				if (success)
				{
					ModelBase<MapModel>.Instance.CreateTempMapMark(traceMarkId);
					ControllerBase<WorldMapController>.Instance.FocalMarkItem((EMarkType)config.Value.ObjectType, traceMarkId);
				}
			});
		}

		// Token: 0x0402563E RID: 153150
		public int Id;

		// Token: 0x0402563F RID: 153151
		public int Current;

		// Token: 0x04025640 RID: 153152
		public int Target;

		// Token: 0x04025641 RID: 153153
		public ECoopSubConditionType TaskType;

		// Token: 0x04025642 RID: 153154
		public string Title = "";
	}
}
