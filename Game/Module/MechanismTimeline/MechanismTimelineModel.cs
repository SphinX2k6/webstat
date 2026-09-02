using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.MechanismTimeline.MechanismEvent;
using UnrealEngine;

namespace CSharpScript.Game.Module.MechanismTimeline
{
	// Token: 0x020057DC RID: 22492
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class MechanismTimelineModel : ModelBase<MechanismTimelineModel>
	{
		// Token: 0x0603926D RID: 234093 RVA: 0x00E7DA08 File Offset: 0x00E7BC08
		protected override bool OnInit()
		{
			bool result = base.OnInit();
			Singleton<MechanismEventCenter>.Instance.RegisterEvents();
			return result;
		}

		// Token: 0x0603926E RID: 234094 RVA: 0x00E7DA1A File Offset: 0x00E7BC1A
		protected override bool OnClear()
		{
			Singleton<MechanismEventCenter>.Instance.Clear();
			return base.OnClear();
		}

		// Token: 0x0603926F RID: 234095 RVA: 0x00E7DA2C File Offset: 0x00E7BC2C
		public void RegisterSequenceContext(UMovieSceneSequencePlayer sequencePlayer, MechanismEventContext context)
		{
			if (sequencePlayer == null || !sequencePlayer.IsValid())
			{
				return;
			}
			this.MechanismEventContext.Set(sequencePlayer, context);
		}

		// Token: 0x06039270 RID: 234096 RVA: 0x00E7DA4D File Offset: 0x00E7BC4D
		public void UnRegisterSequenceContext(UMovieSceneSequencePlayer sequencePlayer)
		{
			if (sequencePlayer == null || !sequencePlayer.IsValid())
			{
				return;
			}
			this.MechanismEventContext.Remove(sequencePlayer);
		}

		// Token: 0x06039271 RID: 234097 RVA: 0x00E7DA70 File Offset: 0x00E7BC70
		[return: Nullable(2)]
		public MechanismEventContext GetContextByPlayer(UMovieSceneSequencePlayer sequencePlayer)
		{
			MechanismEventContext result;
			if (!this.MechanismEventContext.TryGetValue(sequencePlayer, out result))
			{
				return null;
			}
			return result;
		}

		// Token: 0x0402086A RID: 133226
		private readonly WeakMap<UMovieSceneSequencePlayer, MechanismEventContext> MechanismEventContext = new WeakMap<UMovieSceneSequencePlayer, MechanismEventContext>();
	}
}
