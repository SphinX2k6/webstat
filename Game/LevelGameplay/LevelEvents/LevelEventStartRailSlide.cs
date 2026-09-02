using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.NewWorld.Character.Common.Component.Move;
using CSharpScript.Game.NewWorld.Character.Common.Controller;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006C0C RID: 27660
	public class LevelEventStartRailSlide : LevelEventBase
	{
		// Token: 0x06044170 RID: 278896 RVA: 0x011ADCB9 File Offset: 0x011ABEB9
		public LevelEventStartRailSlide(int id) : base(id)
		{
		}

		// Token: 0x06044171 RID: 278897 RVA: 0x011ADCC4 File Offset: 0x011ABEC4
		[NullableContext(1)]
		public override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			if (inParams == null)
			{
				Singleton<global::Log>.Instance.Error(ELogModule.Event, ELogAuthor.CWZ, "LevelEventStartRailSlide 参数配置错误", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			SlideRailStart slideRailStart = inParams as SlideRailStart;
			ISlideRailFollowConfig slideRailFollowConfig = slideRailStart.SlideRailFollowConfig;
			if (((slideRailFollowConfig != null) ? slideRailFollowConfig.FollowDaPath : null) != null)
			{
				int entityId = slideRailStart.SlideRailFollowConfig.EntityId;
				string slidePerformDaPath = slideRailStart.SlidePerformDaPath;
				string followDaPath = slideRailStart.SlideRailFollowConfig.FollowDaPath;
				ControllerBase<CharacterRailSlideController>.Instance.AddRailFollower(entityId, slideRailStart.RailEntityId, followDaPath, slidePerformDaPath);
				return;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			Entity entity = (baseCharacter != null) ? baseCharacter.GetEntityNoBlueprint() : null;
			if (entity == null)
			{
				return;
			}
			CharacterRailSlideComponent component = entity.GetComponent<CharacterRailSlideComponent>();
			if (component == null)
			{
				return;
			}
			component.StartRailSlide(slideRailStart.RailEntityId, slideRailStart.SlidePerformDaPath, null);
		}
	}
}
