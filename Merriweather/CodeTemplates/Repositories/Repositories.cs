


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Merriweather.Mvc.Data.DataModels;
using SubSonic.DataProviders;
using SubSonic.Extensions;
using System.Linq.Expressions;
using SubSonic.Schema;
using System.Collections;
using SubSonic;
using SubSonic.Repository;
using System.ComponentModel;
using System.Data.Common;
using Web.Infrastructure.Storage;
using Merriweather.Universal;

namespace Merriweather.Mvc.Data
{
    
    
    /// <summary>
    /// A class which represents the ArtistRepository table in the Merriweather Database.
    /// </summary>
    public partial class ArtistRepository
    {
		private static ISession _session;
        public ArtistRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<ArtistModel> _ArtistModels;
        protected IEnumerable<ArtistModel> ArtistModels
		{
			get{ 
			if(_ArtistModels== null)
				_ArtistModels= _session.All<Artist>().ConvertToObject<IEnumerable<ArtistModel>>();
			return _ArtistModels;}
			set{
				_ArtistModels =value;
				}
		}
        
        public ArtistModel SingleOrDefault(Func<ArtistModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<ArtistModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<ArtistModel> Find(Func<ArtistModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<ArtistModel> All() {
            return ArtistModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(ArtistModel model){

            
            _session.Add(model);
        }

		public void Edit(ArtistModel model)
		{
			var record = _session.Single<Artist>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(ArtistModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Artist, bool>> expression) {
            
            _session.Delete<Artist>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the AlbumRepository table in the Merriweather Database.
    /// </summary>
    public partial class AlbumRepository
    {
		private static ISession _session;
        public AlbumRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<AlbumModel> _AlbumModels;
        protected IEnumerable<AlbumModel> AlbumModels
		{
			get{ 
			if(_AlbumModels== null)
				_AlbumModels= _session.All<Album>().ConvertToObject<IEnumerable<AlbumModel>>();
			return _AlbumModels;}
			set{
				_AlbumModels =value;
				}
		}
        
        public AlbumModel SingleOrDefault(Func<AlbumModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<AlbumModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<AlbumModel> Find(Func<AlbumModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<AlbumModel> All() {
            return AlbumModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(AlbumModel model){

            
            _session.Add(model);
        }

		public void Edit(AlbumModel model)
		{
			var record = _session.Single<Album>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(AlbumModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Album, bool>> expression) {
            
            _session.Delete<Album>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the SongRepository table in the Merriweather Database.
    /// </summary>
    public partial class SongRepository
    {
		private static ISession _session;
        public SongRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<SongModel> _SongModels;
        protected IEnumerable<SongModel> SongModels
		{
			get{ 
			if(_SongModels== null)
				_SongModels= _session.All<Song>().ConvertToObject<IEnumerable<SongModel>>();
			return _SongModels;}
			set{
				_SongModels =value;
				}
		}
        
        public SongModel SingleOrDefault(Func<SongModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<SongModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<SongModel> Find(Func<SongModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<SongModel> All() {
            return SongModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(SongModel model){

            
            _session.Add(model);
        }

		public void Edit(SongModel model)
		{
			var record = _session.Single<Song>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(SongModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Song, bool>> expression) {
            
            _session.Delete<Song>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the BandRepository table in the Merriweather Database.
    /// </summary>
    public partial class BandRepository
    {
		private static ISession _session;
        public BandRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<BandModel> _BandModels;
        protected IEnumerable<BandModel> BandModels
		{
			get{ 
			if(_BandModels== null)
				_BandModels= _session.All<Band>().ConvertToObject<IEnumerable<BandModel>>();
			return _BandModels;}
			set{
				_BandModels =value;
				}
		}
        
        public BandModel SingleOrDefault(Func<BandModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<BandModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<BandModel> Find(Func<BandModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<BandModel> All() {
            return BandModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(BandModel model){

            
            _session.Add(model);
        }

		public void Edit(BandModel model)
		{
			var record = _session.Single<Band>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(BandModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Band, bool>> expression) {
            
            _session.Delete<Band>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the GenreRepository table in the Merriweather Database.
    /// </summary>
    public partial class GenreRepository
    {
		private static ISession _session;
        public GenreRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<GenreModel> _GenreModels;
        protected IEnumerable<GenreModel> GenreModels
		{
			get{ 
			if(_GenreModels== null)
				_GenreModels= _session.All<Genre>().ConvertToObject<IEnumerable<GenreModel>>();
			return _GenreModels;}
			set{
				_GenreModels =value;
				}
		}
        
        public GenreModel SingleOrDefault(Func<GenreModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<GenreModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<GenreModel> Find(Func<GenreModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<GenreModel> All() {
            return GenreModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(GenreModel model){

            
            _session.Add(model);
        }

		public void Edit(GenreModel model)
		{
			var record = _session.Single<Genre>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(GenreModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Genre, bool>> expression) {
            
            _session.Delete<Genre>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the WebpageRepository table in the Merriweather Database.
    /// </summary>
    public partial class WebpageRepository
    {
		private static ISession _session;
        public WebpageRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<WebpageModel> _WebpageModels;
        protected IEnumerable<WebpageModel> WebpageModels
		{
			get{ 
			if(_WebpageModels== null)
				_WebpageModels= _session.All<Webpage>().ConvertToObject<IEnumerable<WebpageModel>>();
			return _WebpageModels;}
			set{
				_WebpageModels =value;
				}
		}
        
        public WebpageModel SingleOrDefault(Func<WebpageModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<WebpageModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<WebpageModel> Find(Func<WebpageModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<WebpageModel> All() {
            return WebpageModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(WebpageModel model){

            
            _session.Add(model);
        }

		public void Edit(WebpageModel model)
		{
			var record = _session.Single<Webpage>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(WebpageModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<Webpage, bool>> expression) {
            
            _session.Delete<Webpage>(expression);
        }

     }
    
    
    /// <summary>
    /// A class which represents the UserLayoutRepository table in the Merriweather Database.
    /// </summary>
    public partial class UserLayoutRepository
    {
		private static ISession _session;
        public UserLayoutRepository(ISession session)
		{
			if(_session == null)
				_session = session;
		}
        
		private IEnumerable<UserLayoutModel> _UserLayoutModels;
        protected IEnumerable<UserLayoutModel> UserLayoutModels
		{
			get{ 
			if(_UserLayoutModels== null)
				_UserLayoutModels= _session.All<UserLayout>().ConvertToObject<IEnumerable<UserLayoutModel>>();
			return _UserLayoutModels;}
			set{
				_UserLayoutModels =value;
				}
		}
        
        public UserLayoutModel SingleOrDefault(Func<UserLayoutModel, bool> expression) {

            var result = All().Single(expression);

            return result;
        }      
         
        public bool Exists(Func<UserLayoutModel, bool> expression) {
           
            return All().Any(expression);
        }        

        public IList<UserLayoutModel> Find(Func<UserLayoutModel, bool> expression) {
            return All().Where(expression).ToList();
        }
		
        public IEnumerable<UserLayoutModel> All() {
            return UserLayoutModels;
        }
        
        public void Update(){
            _session.CommitChanges();
			_session = null;
        }
		
       
        public void Add(UserLayoutModel model){

            
            _session.Add(model);
        }

		public void Edit(UserLayoutModel model)
		{
			var record = _session.Single<UserLayout>(x=>x.Id == model.Id);
			record.Update(model);
			_session.CommitChanges();
		}

        public void Delete(UserLayoutModel model) {
            _session.Delete(model);
        }



        public  void Delete(Expression<Func<UserLayout, bool>> expression) {
            
            _session.Delete<UserLayout>(expression);
        }

     }
}
