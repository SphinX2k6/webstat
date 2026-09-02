using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Camera;

namespace CSharpScript.Game.LevelGamePlay.LevelEvents
{
	// Token: 0x02006B92 RID: 27538
	public class LevelEventEnterMovieCamera : LevelEventBase
	{
		// Token: 0x06043F59 RID: 278361 RVA: 0x0119B473 File Offset: 0x01199673
		public LevelEventEnterMovieCamera(int id) : base(id)
		{
		}

		// Token: 0x06043F5A RID: 278362 RVA: 0x0119B47C File Offset: 0x0119967C
		[NullableContext(1)]
		public unsafe override void ExecuteNew(ActionParams inParams, GeneralContext context, int? actionId = null)
		{
			EnterMovieCamera enterMovieCamera = inParams as EnterMovieCamera;
			if (enterMovieCamera == null)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			this.Params = enterMovieCamera;
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Event;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[电影镜头]通过LevelEvent进入电影镜头";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", enterMovieCamera.MovieCameraConfig.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			string rowName;
			if (this.Params.MovieCameraConfig.Type == EMovieCameraType.Common)
			{
				IEnterCommonMovieCamera enterCommonMovieCamera = this.Params.MovieCameraConfig as IEnterCommonMovieCamera;
				string rowName = enterCommonMovieCamera.RowName;
				int initialIndex = enterCommonMovieCamera.SpecElementIndex.GetValueOrDefault(-1);
				ModelBase<CameraModel>.Instance.MainModel.PlayMovieCamera(rowName, initialIndex, delegate(bool success)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.Event;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "[电影镜头]通过LevelEvent进入常规电影镜头结果";
					<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", success);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", rowName);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("InitialIndex", initialIndex);
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
					this.FinishExecute(success, false, true);
				});
				return;
			}
			if (this.Params.MovieCameraConfig.Type == EMovieCameraType.Spec)
			{
				IEnterSpecMovieCamera enterSpecMovieCamera = this.Params.MovieCameraConfig as IEnterSpecMovieCamera;
				string rowName = enterSpecMovieCamera.RowName;
				ModelBase<CameraModel>.Instance.MainModel.PlaySpecialMovieCamera(rowName, delegate(bool success)
				{
					global::Log instance3 = Singleton<global::Log>.Instance;
					ELogModule module3 = ELogModule.Event;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "[电影镜头]通过LevelEvent进入特殊电影镜头结果";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", success);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", rowName);
					instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.FinishExecute(success, false, true);
				});
				return;
			}
			if (this.Params.MovieCameraConfig.Type != EMovieCameraType.RandomInGroup)
			{
				base.FinishExecute(false, false, true);
				return;
			}
			IEnterRandomMovieCamera enterRandomMovieCamera = this.Params.MovieCameraConfig as IEnterRandomMovieCamera;
			rowName = Singleton<MathUtils>.Instance.GetRandomItem<string>(enterRandomMovieCamera.RowNames);
			if (rowName == null)
			{
				global::Log instance2 = Singleton<global::Log>.Instance;
				ELogModule module2 = ELogModule.Event;
				ELogAuthor author2 = ELogAuthor.LJM;
				string message2 = "[电影镜头]通过LevelEvent进入随机电影镜头结果:没有配置电影镜头随机列表";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("success", "false");
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				base.FinishExecute(false, false, true);
				return;
			}
			ModelBase<CameraModel>.Instance.MainModel.PlayMovieCamera(rowName, -1, delegate(bool success)
			{
				global::Log instance3 = Singleton<global::Log>.Instance;
				ELogModule module3 = ELogModule.Event;
				ELogAuthor author3 = ELogAuthor.LJM;
				string message3 = "[电影镜头]通过LevelEvent进入随机电影镜头结果";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("success", success);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowName", rowName);
				instance3.Info(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				this.FinishExecute(success, false, true);
			});
		}

		// Token: 0x0402600D RID: 155661
		[Nullable(2)]
		private EnterMovieCamera Params;
	}
}
