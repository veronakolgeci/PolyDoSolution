using AutoMapper;
using PolyDo.Application.DTOs;
using PolyDo.Domain.Entities;
using PolyDo.Domain.Repositories;
using PolyDo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Application.Services {
    public class TaskListService : ITaskListService {
        private readonly ITaskListRepository taskListRepository;
        private readonly IMapper mapper;

        public TaskListService(ITaskListRepository taskListRepository, IMapper mapper) {
            this.taskListRepository = taskListRepository;
            this.mapper = mapper;
        }

        public async Task AddListAsync(TaskListDto list) {
            var mapped = mapper.Map<TaskList>(list);
            await taskListRepository.AddListAsync(mapped);
        }

        public async Task DeleteListAsync(int id) {
            await taskListRepository.DeleteListAsync(id);
        }

        public async Task<IEnumerable<TaskListDto>> GetAllListsAsync() {
            var tasklist = await taskListRepository.GetAllListsAsync();
            var mapped = mapper.Map<IEnumerable<TaskListDto>>(tasklist);

            return mapped;
        }

        public async Task<TaskListDto> GetListByIdAsync(int id) {
            var tasklist = await taskListRepository.GetListByIdAsync(id);
            var mapped = mapper.Map<TaskListDto>(tasklist);

            return mapped;
        }

        public async Task UpdateListAsync(TaskListDto list) {
            var mapped = mapper.Map<TaskList>(list);
            await taskListRepository.UpdateListAsync(mapped);
        }
    }
}
