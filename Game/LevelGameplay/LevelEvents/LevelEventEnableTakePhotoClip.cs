using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B90 RID: 27536
	public class LevelEventEnableTakePhotoClip : LevelEventBase
	{
		// Token: 0x06043F55 RID: 278357 RVA: 0x0119B3D2 File Offset: 0x011995D2
		public LevelEventEnableTakePhotoClip(int id) : base(id)
		{
		}

		// Token: 0x06043F56 RID: 278358 RVA: 0x0119B3DC File Offset: 0x011995DC
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (context.Type.GetValueOrDefault() != EGeneralContextType.Entity)
			{
				return;
			}
			EntityContext entityContext = context as EntityContext;
			if (string.IsNullOrEmpty(entityContext.SequencePath))
			{
				return;
			}
			if ((inParams as EnableTakePhotoClip).Enable)
			{
				ModelBase<PhotographModel>.Instance.SequenceInValidSectionSet.Add(entityContext.SequencePath);
				return;
			}
			ModelBase<PhotographModel>.Instance.SequenceInValidSectionSet.Remove(entityContext.SequencePath);
		}
	}
}
